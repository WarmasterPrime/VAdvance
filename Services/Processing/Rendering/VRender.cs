using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAdvance.Services.Ai.ImageDetection;

namespace VAdvance.Services.Processing.Rendering
{
	public class VRender : Videct
	{

		public void DrawCircle(int h, int k, int radius)
		{
			int x=0;
			int y=0;
			for(int i = h-radius;i<h+radius;i++)
			{
				double calc0=Math.Pow(radius,2) - Math.Pow(i-h,2);
				//double calc1=
			}
		}

	}
}
