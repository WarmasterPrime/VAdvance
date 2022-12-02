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
		private Color[] Items={ };
		private ulong[] Points={ };
		private int Width;
		private int Height;
		/// <summary>
		/// Specifies the minimum cumulative color data value that determines if the sector matches a valid color difference.
		/// </summary>
		public int Threshold=10;
		public int SectorSize=3;
		public byte MaxColorOffset=5;
		private Bitmap Data;
		private BitmapData BMD;
		private Color[][][] Pixels;
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
				if((value!=null) && value.ImageLocation.CheckValue())
				{
					_ImageControl = value;
					_Path=value.ImageLocation;
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

		public Videct()
		{

		}

		public async void ProcessImage()
		{
			for(int y = 0;y<Height;y+=SectorSize*2)
				for(int x = 0;x<Width;x+=SectorSize*2)
					if(IsOverThreshold(x,y))
						await SetPixelSector(x,y,SectorSize*2,SectorSize*2);
			//ImageControl.Image=Image.FromHbitmap(Data.GetHbitmap());
			ImageControl.Image=Image.FromHbitmap(Data.GetHbitmap(Color.Transparent));
		}

		public async void ReplaceColor(Color color)
		{
			if(color!=null)
			{
				for(int y=0;y<Height;y++)
					for(int x=0;x<Width;x++)
			}
		}


		private async Task<bool> SetPixelSector(int x, int y, int width, int height)
		{

			for(int i = y;i<Math.Min(height+y,Height);i++)
			{
				for(int o = x;o<Math.Min(width+x,Width);o++)
				{
					Data.SetPixel(o,i,Color.Red);
				}
			}

			/*
			BMD=Data.LockBits(new Rectangle(x,y,width,height),ImageLockMode.ReadWrite,Data.PixelFormat);
			IntPtr ptr=BMD.Scan0;
			int bytes = Math.Abs(BMD.Stride) * height;
			byte[] rgbs=new byte[bytes];
			Marshal.Copy(ptr,rgbs,0,bytes);
			for(int i = 3;i<rgbs.Length;i+=3)
			{
				rgbs[i]=255;
				await Task.Delay(10);
			}
			Marshal.Copy(rgbs,0,ptr,bytes);
			Data.UnlockBits(BMD);
			*/
			return true;
		}

		private bool IsOverThreshold(int x,int y)
		{
			double r=0;
			for(int i=y;i<Math.Min(y+SectorSize,Data.Height-(SectorSize*2));i+=SectorSize)
				for(int o=x;o<Math.Min(x+SectorSize,Data.Width-(SectorSize*2));o+=SectorSize)
					r+=GetSectorValue(o,i);
			r/=(SectorSize*2);
			return r>Threshold;
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

		private double GetPixelCombinedColor(int x,int y)
		{
			Color c=Data.GetPixel(x,y);
			return ((double)(c.R + c.G + c.B) * (c.A/255)) / 765;
		}



	}
}
