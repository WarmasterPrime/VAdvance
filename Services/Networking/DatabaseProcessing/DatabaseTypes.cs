namespace VAdvance.Services.Networking.DatabaseProcessing
{
	public enum DatabaseTypes
	{
		None=0x0,

		Char					=0x1,
		VarChar					=0x2,
		Binary					=0x3,
		VarBinary				=0x4,
		TinyBlob				=0x5,
		TinyText				=0x6,
		Text					=0x7,
		Blob					=0x8,
		MediumText				=0x9,
		MediumBlob				=0xA,
		LongText				=0xB,
		LongBlob				=0xC,

		Bit						=0xD,
		TinyInt					=0xE,
		Bool					=0xF,
		Boolean					=0xF,
		SmallInt				=0x10,
		MediumInt				=0x11,
		Int						=0x12,
		Integer					=0x12,
		BigInt					=0x13,
		Float					=0x14,
		Double					=0x15,
		Decimal					=0x16,

		Date					=0x17,
		DateTime				=0x18,
		Timestamp				=0x19,
		Time					=0x1A,
		Year					=0x1B,

	}
}
