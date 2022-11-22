using System.Collections.Generic;

namespace VAdvance.Services.Extensions.Strings.Data.Soundex
{
	public static class SoundexReferenceData
	{

		public static readonly string IgnoredRegex="[AEIOUWYHaeiouwyh]+";
		//public static readonly string IgnoredRegex="[A-z]{1}([^AEIOUWYHaeiouwyh]+)[AEIOUWYHaeiouwyh]+";

		public static readonly string[] Ignored={
			"A","E","I","O","U","W","Y","H"
		};

		public static readonly Dictionary<int, string[]> Items=new Dictionary<int, string[]>
		{
			{ 1, new string[]{ "B","P","F","V" } },
			{ 2, new string[]{ "C","S","K","G","J","Q","X","Z" } },
			{ 3, new string[]{ "D","T" } },
			{ 4, new string[]{ "L" } },
			{ 5, new string[]{ "M","N" } },
			{ 6, new string[]{ "R" } }
		};

		public static readonly Dictionary<string,int> ItemsRegex=new Dictionary<string, int>
		{
			{ "[BPFVbpfv]", 1 },
			{ "[CSKGJQXZcskgjqxz]", 2 },
			{ "[DTdt]", 3 },
			{ "[Ll]", 4 },
			{ "[MNmn]", 5 },
			{ "[Rr]", 6 }
		};

		public static readonly Dictionary<string,char> ItemsRegexChar=new Dictionary<string, char>
		{
			{ "[BPFVbpfv]", '1' },
			{ "[CSKGJQXZcskgjqxz]", '2' },
			{ "[DTdt]", '3' },
			{ "[Ll]", '4' },
			{ "[MNmn]", '5' },
			{ "[Rr]", '6' }
		};

	}
}
