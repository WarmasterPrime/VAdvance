using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAdvance.Services.Extensions.Strings
{
	public static class StringLevenshteinExtension
	{

		public static int Levenshtein(this string str, string value, int insertion_cost=1, int replacement_cost=1, int deletion_cost=1)
		{
			if(value.CheckValue() && str.CheckValue())
			{
				int res=str[0]!=value[0] ? 1 : 0;
				int char_length=Math.Min(str.Length,value.Length);
				List<int> character_indexes=GetCharacterIndexes(str,value,char_length);
				foreach(int i in character_indexes)
					if(i>0 && i<char_length && value[i]!=str[i])
						res+=value[i-1]==str[i-1] && value[i+1]==str[i+1] ? replacement_cost : value[i-1]==str[i-1] && value[i]==str[i+1] ? insertion_cost : deletion_cost;
				return res+(deletion_cost*GetValueLengthDifference(str,value));
			}
			return -1;
		}

		private static int GetValueLengthDifference(string first_value,string second_value)
		{
			return first_value.Length>second_value.Length ? first_value.Length-second_value.Length : second_value.Length-first_value.Length;
		}

		private static List<int> GetCharacterIndexes(string first_value,string second_value, int max_length)
		{
			List<int> character_indexes=new List<int>();
			for(int i=0;i<max_length;i++)
				if(first_value[i]!=second_value[i])
					character_indexes.Add(i);
			return character_indexes;
		}

	}
}
