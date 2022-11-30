using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VAdvance.DataTypes.Enumerable;

namespace VAdvance.Services.Extensions.Strings
{
	public static class StringMetaSoundExtension
	{
		/// <summary>
		/// Provides a means to accurately determine the sounds within a string.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string MetaSound(this string value)
		{
			string str=StringMetaphoneExtension.RemoveDuplicateCharacters(value.ToUpper());
			string reg="["+StringValidationExtension.VowelsRegex+"]";
			str=RemoveChars(str);
			return str;
		}

		public static string RemoveChars(string value)
		{
			string res=value;
			Varray l=new Varray
			{
				{"XY","XE" },
				{"XA","XA" },
				{"EN","N" },
				{"PH","F" },
				{"ONE","ON" },
				{"MY","MI" },
				{"IE","E" },
				{"ER","R" },
				{"TION","SHON" },
				{"([A-Z]+)OR","$1R" },
				{"ATE","IT" },
				{"LES","LS" },
				{"RAN","RN" },
				{"GES","GS" },
				{"EGE","ED" },
				{"YS","S" },
				{"Y","E" },
				{"QU","CW" },
				{"ICK","IK" },
				{"THE","T" },
				{"ED","T" },
				{"ROM","RM" },
				{"ROW","WO" },
				{"TE","T" },
				{"CAL","CL" },
				{"CAN","CN" },
				{"C","K" }
			};
			foreach(KeyValuePair<object,object> sel in l.Items)
				if(Regex.IsMatch(res,sel.Key.ToString()))
					res=Regex.Replace(res,sel.Key.ToString(),sel.Value.ToString());
			return res;
		}

	}
}
