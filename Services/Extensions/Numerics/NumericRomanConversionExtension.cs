using VAdvance.Services.Extensions.Strings;

namespace VAdvance.Services.Extensions.Numerics
{
	public static class NumericRomanConversionExtension
	{
		/// <summary>
		/// Converts a roman numeral string value into its integer equivalent.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int GetNumberFromRoman(this string value)
		{
			int res=0;
			int last_num=0;
			if(value.CheckValue())
				foreach(char c in value.ToLower())
				{
					int num=GetNumberFromRomanChar(c);
					res+=num>last_num ? num-(last_num*2) : num;
					last_num=num;
				}
			return res;
		}
		/// <summary>
		/// Gets the integer representation of a given roman numeral character value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int GetNumberFromRomanChar(this char value)
		{
			switch(value)
			{
				case 'i':
					return 1;
				case 'v':
					return 5;
				case 'x':
					return 10;
				case 'l':
					return 50;
				case 'c':
					return 100;
				case 'd':
					return 500;
				case 'm':
					return 1000;
				default:
					return 0;
			}
		}
	}
}
