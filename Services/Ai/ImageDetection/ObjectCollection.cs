using System.Collections.Generic;

namespace VAdvance.Services.Ai.ImageDetection
{
	public class ObjectCollection : List<ImageObjectItem>
	{

		private List<ImageObjectItem> Items=new List<ImageObjectItem>();

		public int GetAveragePixelCount()
		{
			int res=0;
			foreach(ImageObjectItem item in this)
				res+=item.Items.Length;
			return Count>0 ? res/Count : 1;
		}

		public void RemoveBySize(int pixel_count=-1)
		{
			int lim=pixel_count>0 ? pixel_count : GetAveragePixelCount();
			foreach(ImageObjectItem item in this)
				if(item.Items.Length<lim)
					Items.Add(item);
			foreach(ImageObjectItem sel in Items)
				Remove(sel);
		}

		public void Add(int x,int y,int offset=18)
		{
			ImageObjectItem obj=CanConnect(x,y,offset);
			if(obj!=null)
				obj.AddPixel(x,y);
			else
			{
				obj=new ImageObjectItem();
				obj.AddPixel(x,y);
				Add(obj);
			}
		}

		public ImageObjectItem CanConnect(int x,int y,int offset=18)
		{
			foreach(ImageObjectItem item in this)
				if(item.IsConnected(x,y,offset))
					return item;
			return null;
		}


	}
}
