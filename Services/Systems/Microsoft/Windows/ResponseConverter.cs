using System.Collections.Generic;

namespace VAdvance.Services.Systems.Microsoft.Windows
{
	public static class ResponseConverter
	{
		public static readonly Dictionary<int, dynamic> Items=new Dictionary<int, dynamic>{
			{ 0,"x86"},
			{ 1,"MIPS"},
			{ 2,"Alpha"},
			{ 3,"PowerPC"},
			{ 5,"ARM"},
			{ 6,"ia64 (Itanium-based systems)"},
			{ 9,"x64"}
		};
	}
}
