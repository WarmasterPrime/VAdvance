using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAdvance.Services.Networking.DatabaseProcessing
{
	public class DatabaseQueryItem
	{

		private ulong _Count=0;

		public DatabaseCommandFlags Action									=DatabaseCommandFlags.None;
		public readonly List<string> Columns								=new List<string>();
		public readonly Dictionary<string,dynamic> Items					=new Dictionary<string,dynamic>();
		public readonly Dictionary<string,dynamic> Where					=new Dictionary<string,dynamic>();
		public readonly Dictionary<string,dynamic> Like						=new Dictionary<string,dynamic>();
		public readonly Dictionary<string,dynamic> In						=new Dictionary<string,dynamic>();
		public readonly Dictionary<string,dynamic[]> Between				=new Dictionary<string,dynamic[]>();
		public ulong LimitResults											=0;
		public bool AutoIncrement											=true;
		public ulong Count{get{return _Count;}}

	}
}
