using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VAdvance.Services.Ai.ImageDetection
{
	public class AiNormalScan
	{
		private Image _ImageObject;
		private PictureBox _ImageControl;
		private int _Width;
		private int _Height;
		public int Width
		{
			get
			{
				return _Width;
			}
		}
		public int Height
		{
			get
			{
				return _Height;
			}
		}

		public Image ImageObject
		{
			get
			{
				return _ImageObject;
			}
			set
			{
				if((value!=null) && value.Size.Width>0 && value.Size.Height>0)
				{
					_ImageObject=value;
					_Width=value.Size.Width;
					_Height=value.Size.Height;
				}
			}
		}
		public PictureBox ImageControl;


		public AiNormalScan()
		{

		}

		public void Execute()
		{

		}








	}
}
