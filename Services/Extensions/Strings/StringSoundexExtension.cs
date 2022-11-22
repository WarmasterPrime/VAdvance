using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using VAdvance.Services.Extensions.Characters;
using VAdvance.Services.Extensions.Strings.Data.Soundex;

namespace VAdvance.Services.Extensions.Strings
{
	public static class StringSoundexExtension
	{

		public static string Soundex(this string value)
		{
			string res=string.Empty;
			if(value.CheckValue())
			{
				string str=Regex.Replace(value.Substring(1,value.Length-1),"[\\s]+","").ToUpper();
				res+=value[0].ToUpper();
				str=Regex.Replace(Regex.IsMatch(str,SoundexReferenceData.IgnoredRegex) ? Regex.Replace(str,SoundexReferenceData.IgnoredRegex,"") : str,"(.)\\1{1,}","$1");
				var dev=str;
				int i=0;
				while(res.Length<Math.Min(4,str.Length+1))
					res+=GetSoundexCodeFromCharacter(str[i++]);
				if(res.Length<4)
					while(res.Length<4)
						res+='0';
			}
			return res;
		}

		public static char GetSoundexCodeFromCharacter(char value)
		{
			string v=value.ToString();
			foreach(KeyValuePair<string,char> r in SoundexReferenceData.ItemsRegexChar)
				if(Regex.IsMatch(v,r.Key))
					return r.Value;
			return '0';
		}
	}
}
