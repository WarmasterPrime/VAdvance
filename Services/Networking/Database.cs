using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAdvance.DataTypes.Enumerable;

namespace VAdvance.Services.Networking
{
	public class Database
	{
		public readonly DatabaseConfig Configuration=new DatabaseConfig();
		public Varray Results;
		public readonly Dictionary<string,dynamic> ColumnValuePairs=new Dictionary<string,dynamic>();
		public string[] Columns;

		public Database() { }

		public async Task<Varray> ExecuteAsync(string sql)
		{
			Varray res=new Varray();

			return res;
		}



	}
}
