using System.Text.RegularExpressions;

namespace VAdvance.Services.Extensions.Strings
{
	public static class StringModificationExtension
	{
		/// <summary>
		/// Repeats a string value a specified number of times.
		/// </summary>
		/// <param name="value">Obtained from an instance of a string.</param>
		/// <param name="repeat_limit">The number of times to repeat the value.</param>
		/// <returns></returns>
		public static string Repeat(this string value,uint repeat_limit)
		{
			string res=value;
			if(value.CheckValue()&&repeat_limit>0)
				for(uint i=0;i<repeat_limit;i++)
					res+=value;
			return res;
		}
		/// <summary>
		/// Capitalizes the contents of the string value.
		/// </summary>
		/// <param name="value">Obtained from an instance of a string.</param>
		/// <param name="flags">Controls </param>
		/// <param name="custom_value"></param>
		/// <returns></returns>
		public static string Capitalize(this string value,StringModificationFlags flags,dynamic custom_value=null)
		{
			string res=value;
			if(value.CheckValue())
			{
				string rex=string.Empty;
				if(flags>=StringModificationFlags.ByCustomCharacter&&((custom_value!=null)&&custom_value is char))
					rex="\\"+custom_value;
				else if(flags==StringModificationFlags.Custom&&((custom_value is string)&&custom_value.CheckValue()))
					rex=custom_value;
				else
				{
					if(flags>=StringModificationFlags.BySentence)
						rex+="\\.\\!\\?\\:\\;\n\r\f";
					if(flags>=StringModificationFlags.ByWhitespace)
						rex+="\\s";
					if(flags>=StringModificationFlags.BySpecialCharacter)
						rex+="\\W\\_";
				}
				res=new Regex("((["+rex+"A-Z]*)([a-z])([^"+rex+"]+))").Replace(value,delegate (Match m)
				{
					return Regex.IsMatch(m.Groups[2].Value,"[A-Z]+") ? m.Groups[1].Value : m.Groups[2].Value+(m.Groups[3].Value.ToUpper())+m.Groups[4].Value.ToLower();
				});
			}
			return res;
		}
	}
}
