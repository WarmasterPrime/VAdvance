using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VAdvance.DataTypes.Enumerable;
using VAdvance.Services.Extensions.Strings;

namespace VAdvance.Services.Networking
{
	public class Database
	{
		public readonly DatabaseConfig Configuration=new DatabaseConfig();
		public Varray Results;
		public readonly Dictionary<string,dynamic> ColumnValuePairs=new Dictionary<string,dynamic>();
		public string[] Columns;
		private bool IsOpen=false;
		private SqlConnection Con;
		public DatabaseCommandFlags Action=DatabaseCommandFlags.None;

		public Database() { }

		public async Task<dynamic> ExecuteRawAsync(string sql)
		{
			dynamic res=null;
			PrepareConnection();
			Open();
			SqlCommand cmd=new SqlCommand(sql,Con);
			if(HasOutput(GetAction(sql)))
			{
				SqlDataReader dr=await cmd.ExecuteReaderAsync();
				if(dr.HasRows)
				{
					res=new Varray();
					while(dr.Read())
						foreach(DbColumn sel in dr.GetColumnSchema())
							res.Add(new Varray { sel.ColumnName,dr[sel.ColumnName] });
					return res;
				}
			}
			Close();
			return res;
		}

		public async Task<dynamic> ExecuteAsync()
		{
			dynamic res=null;
			PrepareConnection();
			Open();
			string action="";
			SqlCommand cmd=new SqlCommand(action,Con);
			Close();
			return res;
		}

		private string GenerateSql()
		{
			string res="";
			return res;
		}

		private static string GetAction(string sql)
		{
			return sql.CheckValue() && Regex.IsMatch(sql,"\\A^([A-z]+)") ? Regex.Match(sql,"\\A^([A-z]+)").Value : null;
		}

		private static bool HasOutput(string action)
		{
			return action.ToLower()=="select";
		}

		private void PrepareConnection()
		{
			if(!IsOpen)
				Con=new SqlConnection(Configuration.ConnectionString);
		}

		private void Open()
		{
			if(!IsOpen)
			{
				Con.Open();
				IsOpen=true;
			}
		}

		private void Close()
		{
			if(IsOpen)
			{
				Con.Close();
				IsOpen=false;
			}
		}


	}
}
