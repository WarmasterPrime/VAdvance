using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VAdvance.Services.Extensions.Strings;
using VAdvance.Services.Extensions.Strings.Data.FileSystem;

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
		public int Threshold=5;
		public int SectorSize=3;
		private Bitmap Data;
		public string Path
		{
			get { return _Path; }
			set
			{
				_Path = FileExtensions.Image.Contains(value.GetExtension()) ? value : null;
			}
		}
		public PictureBox ImageControl;

		public Videct()
		{

		}

		public async void ProcessImage()
		{
			Path=ImageControl.ImageLocation;
			Data = new Bitmap(ImageControl.Image);
			Width=Data.Width;
			Height=Data.Height;
			
			for(int y = 0;y<Data.Height;y+=SectorSize)
				for(int x = 0;x<Data.Width;x+=SectorSize)
				{

				}
			
		}


		private bool IsOverThreshold(int x,int y)
		{
			return true;
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
				for(int o=x;o<Math.Min(SectorSize+x,Data.Width-SectorSize);o++)
				{
					
				}
			}
			return res;
		}

		private double GetPixelCombinedColor(int x,int y)
		{
			Color c=Data.GetPixel(x,y);
			return ((double)(c.R + c.G + c.B) * (c.A/255)) / 765;
		}



	}
}
