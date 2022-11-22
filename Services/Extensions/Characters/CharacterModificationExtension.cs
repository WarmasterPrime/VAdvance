namespace VAdvance.Services.Extensions.Characters
{
	public static class CharacterModificationExtension
	{
		/// <summary>
		/// Converts the character into its uppercase equivalent.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static char ToUpper(this char value)
		{
			return value.IsLower() ? (char)(value-32) : value;
		}
		/// <summary>
		/// Converts the character into its lowercase equivalent.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static char ToLower(this char value)
		{
			return value.IsUpper() ? (char)(value+32) : value;
		}
	}
}
