using System.Linq;

namespace VAdvance.Services.Extensions.Characters
{
	public static class CharacterValidationExtension
	{
		private static readonly int[] WhitespaceCodes={
			9,10,11,12,13,32,8203
		};
		/// <summary>
		/// Determines if the character is practical for normal user input reading.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool CheckValue(this char value)
		{
			return value>31&&value<256;
		}
		/// <summary>
		/// Determines if the character is an uppercase letter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsUpper(this char value)
		{
			return value>64&&value<91;
		}
		/// <summary>
		/// Determines if the character is a lowercase letter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsLower(this char value)
		{
			return value>96&&value<123;
		}
		/// <summary>
		/// Determines if the character represents a numerical value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsNumeric(this char value)
		{
			return value>47&&value<58;
		}
		/// <summary>
		/// Determines if the character represents a computer command code.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsCommand(this char value)
		{
			return value>-1&&value<32 && !WhitespaceCodes.Contains(value);
		}
		/// <summary>
		/// Determines if the character represents a whitespace value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsWhitespace(this char value)
		{
			return WhitespaceCodes.Contains(value);
		}
		/// <summary>
		/// Determines if the character represents a letter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsAlpha(this char value)
		{
			return value.IsUpper()||value.IsLower();
		}
		/// <summary>
		/// Determines if the character represents an alpha numeric value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsAlphaNumeric(this char value)
		{
			return value.IsAlpha()||value.IsNumeric();
		}
		/// <summary>
		/// Determines if the character represents a word character (Excluding periods and other syntax characters).
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsWord(this char value)
		{
			return value.IsAlphaNumeric()||value.IsWhitespace();
		}
		/// <summary>
		/// Determines if the character represents a symbol value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsSymbol(this char value)
		{
			return value>32&&!value.IsWord();
		}
	}
}
