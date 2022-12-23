using System.Text.RegularExpressions;

namespace VAdvance.Services.Extensions.Strings
{

	public static class StringValidationExtension
	{
		public static readonly string[] Vowels={
			"a","A","e","E","i","I","o","O","u","U","y","Y"
		};
		public static readonly string VowelsRegex="aAeEiIoOuUyY";
		/// <summary>
		/// Determines if the string value is usable or valid.
		/// </summary>
		/// <param name="value">Obtained from an instance of a string.</param>
		/// <returns><see cref="bool">true</see> if the value passes validation, <see cref="bool">false</see> otherwise.</returns>
		public static bool CheckValue(this string value)
		{
			return (!string.IsNullOrEmpty(value))&&value.Trim().Length>0;
		}
		/// <summary>
		/// Determines if the string consists of only numbers.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="ignore_whitespace"></param>
		/// <returns></returns>
		public static bool ContainsOnlyNumbers(this string value, bool ignore_whitespace=false)
		{
			return Regex.IsMatch(value,"[^\\d"+(ignore_whitespace ? "\\s" : "")+"]+");
		}
		/// <summary>
		/// Determines if the string value consists of only numerical characters (Includes numbers, numerical symbols, and alphametical unit representations).
		/// </summary>
		/// <param name="value"></param>
		/// <param name="ignore_whitespace"></param>
		/// <returns></returns>
		public static bool ContainsOnlyNumerics(this string value, bool ignore_whitespace=false)
		{
			return Regex.IsMatch(value,"[^\\deE.-"+(ignore_whitespace ? "\\s" : "")+"]+");
		}
		/// <summary>
		/// Determines if the string value contains at least one of the items within the array of string values.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public static bool ContainsAny(this string value, string[] values)
		{
			if(values!=null)
				foreach(string sel in values)
					if((sel!=null) && value.Contains(sel))
						return true;
			return false;
		}
		/// <summary>
		/// Determines if the string value contains all of the values provided within the array of strings.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public static bool ContainsAll(this string value, string[] values)
		{
			if((values!=null) && values.Length>0 && value.CheckValue())
			{
				foreach(string sel in values)
					if((sel!=null) && !value.Contains(sel))
						return false;
				return true;
			}
			return false;
		}

	}
}
