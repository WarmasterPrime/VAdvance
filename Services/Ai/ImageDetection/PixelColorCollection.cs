using System;
using System.Collections.Generic;
using System.Drawing;

namespace VAdvance.Services.Ai.ImageDetection
{
	public class PixelColorCollection : Dictionary<ulong,Dictionary<ulong,Color>>
	{
		public PixelColorCollection() { }

		public PixelColorItem[] FindAll(Color color)
		{
			PixelColorItem[] res={ };
			foreach(var sel in this)
				if(sel.Value.ContainsValue(color))
					foreach(var s in sel.Value)
					{
						Array.Resize(ref res,res.Length+1);
						res[res.Length-1]=new PixelColorItem
						{
							X=sel.Key,
							Y=s.Key,
							Color=s.Value
						};
					}
			return res;
		}
	}
}
