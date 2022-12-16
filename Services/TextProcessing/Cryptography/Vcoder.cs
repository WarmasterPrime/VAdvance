using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAdvance.Services.TextProcessing.Cryptography
{
	public class Vcoder
	{

		public long Seed;
		private readonly DateTime Timestamp;

		public Vcoder()
		{
			Timestamp=DateTime.Now;
			Seed=Timestamp.Ticks;
		}

		public string Encode(string value)
		{
			string res="";
			foreach(char sel in value)
				res+=GetEncodedChar(sel);
			return res;
		}

		private char GetEncodedChar(char value)
		{
			int num=(int)(value%2==0 ? (((value+2)/2) + (Seed/(Seed/4))) / (Seed/3) : value-(Seed/(Seed/6)));
			if(num<0)
				num+=Math.Abs(num);
			if(num>254)
				num-=254*(num/254);
			return num<0 ? (char)(num+1*num/2) : (char)(num+1);
		}


	}
}
