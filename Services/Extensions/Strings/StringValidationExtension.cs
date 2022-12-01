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

	}
}
