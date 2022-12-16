namespace VAdvance.Services.Networking.DatabaseProcessing
{
	public enum DatabaseCommandFlags
	{
		None=0x0,
		Select=0x1,
		Count=0x2,
		Insert=0x4,
		SelectInto=0x8,
		Update=0x10,
		Delete=0x20,
		DropTable=0x40,
		DropDatabase=0x80,
		CreateDatabase=0x100,
		CreateTable=0x200,
		AutoCreateTable=0x400,
		CheckTableExists=0x800,
		CheckDatabaseExists=0x1000,
		AlterTable=0x2000
	}
}
