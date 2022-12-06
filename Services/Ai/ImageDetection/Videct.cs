using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VAdvance.Services.Extensions.Strings;
using VAdvance.Services.Extensions.Strings.Data.FileSystem;
using System.Runtime;
using System.Runtime.InteropServices;

namespace VAdvance.Services.Ai.ImageDetection
{
	public class Videct
	{

		private string _Path;
		//private Color[] Items={ };
		//private ulong[] Points={ };
		private int Width;
		private int Height;
		/// <summary>
		/// Specifies the minimum cumulative color data value that determines if the sector matches a valid color difference.
		/// </summary>
		public int Threshold=5;
		public int SectorSize=3;
		public byte MaxColorOffset=5;
		private Bitmap Data;
		//private BitmapData BMD;
		//private Color[][][] Pixels;
		private static readonly Color DefaultColor=Color.Red;
		private double LastColorIndex=-1;

		private readonly ObjectCollection Objects=new ObjectCollection();

		public string Path
		{
			get { return _Path; }
			set
			{
				_Path = FileExtensions.Image.Contains(value.GetExtension()) ? value : null;
			}
		}
		private PictureBox _ImageControl;
		public PictureBox ImageControl
		{
			get
			{
				return _ImageControl;
			}
			set
			{
				if(value!=null)
				{
					_ImageControl = value;
					//_Path=value.ImageLocation.CheckPath() ? value.ImageLocation : null;
					Path=value.ImageLocation;
					if(Data!=null)
						Data.Dispose();
					Data=new Bitmap(value.Image);
					Width=Data.Width;
					Height=Data.Height;
				}
				else
				{
					_ImageControl=null;
					_Path=null;
				}
			}
		}

		private int PosY=0;
		private int PosX=0;

		public Videct()
		{

		}

		public async void OutlineImage()
		{
			await Task.Delay(1);
			int s0=SectorSize*2;
			for(int y = 0;y<Height;y+=s0)
			{
				for(int x = 0;x<Width-s0;x+=s0)
					if(IsOverThreshold(x,y))
						SetPixelSector(x,y,s0,s0,DefaultColor);
				LastColorIndex=-1;
			}
			FinalizeImage();
		}

		public void ProcessImage()
		{
			int s0=SectorSize*2;
			for(int y = 0;y<Height;y+=s0)
			{
				for(int x = 0;x<Width-s0;x+=s0)
					if(IsOverThreshold(x,y))
						Objects.Add(x,y);
				RenderImage();
				LastColorIndex=-1;
			}
			Objects.RemoveBySize();
			foreach(ImageObjectItem sel in Objects)
				foreach(PixelColorItem s in sel.Items)
					SetPixelSector((int)s.X,(int)s.Y,s0,s0,DefaultColor);
			Objects.Clear();
			FinalizeImage();
		}

		private async void RenderImage()
		{
			await Task.Delay(1);
			if((ImageControl!=null) && !ImageControl.IsDisposed)
				ImageControl.Image=Image.FromHbitmap(Data.GetHbitmap(Color.Transparent));
		}

		private bool IterateHeight(int increment)
		{
			if(PosY<Height)
			{
				PosY+=increment;
				return true;
			}
			return false;
		}

		private bool IterateWidth(int increment)
		{
			if(PosX<Width)
			{
				PosX+=increment;
				return true;
			}
			return false;
		}



		private void FinalizeImage()
		{
			ImageControl.Image=Image.FromHbitmap(Data.GetHbitmap(Color.Transparent));
			ImageControl.Refresh();
			Data.Dispose();
			Data=null;
			LastColorIndex=-1;
			Width=0;
			Height=0;
			_Path=null;
			_ImageControl=null;
		}

		/*
		//ToDo: Finish up color replacement utilizing the PixelColorCollection class to iterate through the pixels.
		public async void ReplaceColor(Color color)
		{
			if(color!=null)
			{

			}
		}
		*/
		/// <summary>
		/// Sets/Replaces an area/sector of an image to a given color value.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="color"></param>
		private void SetPixelSector(int x, int y, int width, int height, Color color)
		{
			for(int i = y;i<Math.Min(height+y,Height);i++)
				for(int o = x;o<Math.Min(width+x,Width);o++)
					Data.SetPixel(o,i,color);
		}
		/// <summary>
		/// Determines if the sector value exceeds the maximum color difference threshold.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		private bool IsOverThreshold(int x,int y)
		{
			double r=0;
			for(int i=y;i<Math.Min(y+SectorSize,Data.Height-(SectorSize*2));i+=SectorSize)
				for(int o=x;o<Math.Min(x+SectorSize,Data.Width-(SectorSize*2));o+=SectorSize)
					r+=GetSectorValue(o,i);
			r/=(SectorSize*2);
			r=(r*255)/500;
			if(LastColorIndex<0)
			{
				LastColorIndex=r;
				return false;
			}
			if((Math.Max(r,LastColorIndex) - Math.Min(r,LastColorIndex)) > Threshold)
			{
				LastColorIndex=r;
				return true;
			}
			//return (Math.Max(r,LastColorIndex) - Math.Min(r,LastColorIndex)) > Threshold;
			return false;
		}
		/// <summary>
		/// Calculates the sector value by combining the color values of each pixel within the sector/matrix.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>an <see cref="int">integer</see> value representing the combined/cumulative color value of each pixel within the sector/matrix.</returns>
		private double GetSectorValue(int x,int y)
		{
			double res=0;
			for(int i=y;i<Math.Min(SectorSize+y,Data.Height-SectorSize);i++)
			{
				double r=0;
				for(int o=x;o<Math.Min(SectorSize+x,Data.Width-SectorSize);o++)
					r+=GetPixelCombinedColor(o,i);
				res+=r/SectorSize;
			}
			return res/SectorSize*255;
		}
		/// <summary>
		/// Calculates the pixel color index by adding all color values (red, green, and blue), then multiplies that value by the alpha percentage, then divides that value by 1,020 (255 is the maximum for each color value, but we also include the alpha color value in the total).
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		private double GetPixelCombinedColor(int x,int y)
		{
			Color c=Data.GetPixel(x,y);
			return ((double)(c.R + c.G + c.B) * (c.A/255)) / 1020;
		}



	}
}
