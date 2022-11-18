namespace VAdvance.Services.Extensions.Strings
{
	public enum StringModificationFlags
	{
		None							=0x0,
		BySentence						=0x1,
		ByWhitespace					=0x2,
		BySpecialCharacter				=0x4,
		ByUnicodeCharacter				=0x8,
		ByCustomCharacter				=0x10,
		Custom							=0x20
	}
}
