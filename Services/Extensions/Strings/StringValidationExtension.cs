namespace VAdvance.Services.Extensions.Strings
{
	public static class StringValidationExtension
	{
		/// <summary>
		/// Determines if the string value is usable or valid.
		/// </summary>
		/// <param name="value">Obtained from an instance of a string.</param>
		/// <returns><see cref="bool">true</see> if the value passes validation, <see cref="bool">false</see> otherwise.</returns>
		public static bool CheckValue(this string value)
		{
			return (!string.IsNullOrEmpty(value))&&value.Trim().Length>0;
		}
	}
}
