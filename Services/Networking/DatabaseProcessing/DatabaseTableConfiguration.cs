using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAdvance.Services.Networking.DatabaseProcessing
{
	public class DatabaseTableConfiguration
	{

		public string Name;
		public readonly List<string> Columns							=new List<string>();
		public readonly Dictionary<string,string> Items					=new Dictionary<string, string>();


	}
}
