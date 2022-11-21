using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAdvance.Services.Extensions.Arrays;
using VAdvance.Services.Extensions.Strings;
using VAdvance.Services.Extensions.Types;

namespace VAdvance.Services.Sorting
{
	public class Sorter
	{

		public static dynamic[] Sort(dynamic array, SortingOption options = SortingOption.Ascending)
		{
			if((array!=null) && array.GetType().IsArray && options!=SortingOption.None)
				Array.Sort((dynamic[]) array, SortByAlphaNumeric);
			return options==SortingOption.Descending ? Array.Reverse(array) : array;
		}

		private static int SortByAlphaNumeric(dynamic first,dynamic second)
		{
			return first is string ? StringSortAlphaNum(first,second) : (first!=second ? (first>second ? 1 : -1) : 0);
		}

		private static int StringSortAlphaNum(string first,string second)
		{
			first=first.ToLower();
			second=second.ToLower();
			for(int i=0;i<Math.Min(first.Length,second.Length);i++)
				if(first[i]!=second[i])
					return first[i]>second[i] ? 1 : -1;
			return first.Length>second.Length ? 1 : first.Length==second.Length ? 0 : -1;
		}

	}
}
