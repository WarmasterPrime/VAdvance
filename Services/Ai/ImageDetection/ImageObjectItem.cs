using System;
using System.Collections.Generic;

namespace VAdvance.Services.Ai.ImageDetection
{
	public class ImageObjectItem
	{
		public int X;
		public int Y;
		public int Width;
		public int Height;
		public PixelColorItem[] Items={ };
		public Dictionary<int,Dictionary<int,PixelColorItem>> ImageObjects=new Dictionary<int, Dictionary<int, PixelColorItem>>();

		public void AddPixel(int x,int y,int offset=3)
		{
			if(IsConnected(x,y,offset))
			{
				if(!ImageObjects.ContainsKey(x))
					ImageObjects.Add(x,new Dictionary<int,PixelColorItem> { { y,new PixelColorItem { X=(ulong)x,Y=(ulong)y } } });
				else if(!ImageObjects[x].ContainsKey(y))
					ImageObjects[x].Add(y,new PixelColorItem { X=(ulong)x,Y=(ulong)y });
				Array.Resize(ref Items,Items.Length+1);
				Items[Items.Length-1]=ImageObjects[x][y];
			}
			else if(!ImageObjects.ContainsKey(x))
			{
				ImageObjects.Add(x,new Dictionary<int,PixelColorItem> { { y,new PixelColorItem { X=(ulong)x,Y=(ulong)y } } });
				Array.Resize(ref Items,Items.Length+1);
				Items[Items.Length-1]=ImageObjects[x][y];
			}
		}

		public bool IsConnected(int x,int y,int offset=3)
		{
			return IsWithinRange(x,y,offset)!=null;
		}

		public PixelColorItem IsWithinRange(int x,int y,int offset=3)
		{
			for(int i = x-offset;i<x+offset;i++)
				if(ImageObjects.ContainsKey(i))
					for(int o = y-offset;o<y+offset;o++)
						if(ImageObjects[i].ContainsKey(o))
							return ImageObjects[i][o];
			return null;
		}



	}
}
