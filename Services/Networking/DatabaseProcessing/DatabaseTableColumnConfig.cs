using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAdvance.Services.Extensions.Strings;

namespace VAdvance.Services.Networking.DatabaseProcessing
{
	public class DatabaseTableColumnConfig
	{

		private string _Name;
		private string _Description;

		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				//if(value.CheckValue())

			}
		}
		public string Description;
		public DatabaseTypes Type=DatabaseTypes.None;

	}
}
