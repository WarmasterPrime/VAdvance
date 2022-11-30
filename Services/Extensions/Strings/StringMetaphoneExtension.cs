using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VAdvance.DataTypes.Enumerable;

namespace VAdvance.Services.Extensions.Strings
{
	public static class StringMetaphoneExtension
	{

		public static string Metaphone(this string value)
		{
			string str=SimplifySounds(RemoveDuplicateCharacters(value.ToUpper()));
			if(Regex.IsMatch(str,"MB[\\s$\\z]+"))
				str=Regex.Replace(str,"MB[\\s$\\z]+","M");
			str=ConvertSimilarSounds(str);
			return value;
		}

		public static string RemoveDuplicateCharacters(string value)
		{
			return Regex.IsMatch(value,"(.)\\1") ? Regex.Replace(value,"(.)\\1","$1") : value;
		}

		public static string ConvertSimilarSounds(string value)
		{
			string res=value;
			if(Regex.IsMatch(res,"CIA|SCH|CH|C"))
			{
				Varray l=new Varray{
					{"CIA","XIZ" },
					{"SCH","SKH" },
					{"CH","XH" },
					{"C","K" },
					{"CL","SI" },
					{"CE","SE" },
					{"CY","SY" },
					{"DGE","JGE" },
					{"DGY","JGY" },
					{"DGI","DGY" },
					{"D","T" }
				};
				foreach(KeyValuePair<string,string> sel in l)
					if(Regex.IsMatch(res,sel.Key))
						res=Regex.Replace(res,sel.Key,sel.Value);
			}
			return res;
		}

		public static string SimplifySounds(string value)
		{
			if(Regex.IsMatch(value,"^(KN|GN|PN|AE|WR)"))
			{
				string beginning=Regex.Match(value,"^(KN|GN|PN|AE|WR)").Captures[0].Value;
				string rep=null;
				if(beginning=="KN"||beginning=="GN"||beginning=="PN")
					rep="N";
				else
					switch(beginning)
					{
						case "AE":
							rep="A";
							break;
						case "WR":
							rep="R";
							break;
					}
				return rep!=null ? Regex.Replace(value,"^(kn|gn|pn|ae|wr)",rep) : value;
			}
			return value;
		}


	}
}
