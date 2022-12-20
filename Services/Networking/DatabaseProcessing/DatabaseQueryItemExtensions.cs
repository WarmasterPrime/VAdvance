using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAdvance.DataTypes.Enumerable;
using VAdvance.Services.Extensions.Objects;

namespace VAdvance.Services.Networking.DatabaseProcessing
{
	public static class DatabaseQueryItemExtensions
	{

		public static string GetWheres(this DatabaseQueryItem item)
		{
			string res="";
			foreach(KeyValuePair<string, dynamic> sel in item.Where)
				res+=(res.Length>0 ? " AND " : "") + "'" + sel.Key + "' = "+GetValue(sel.Value)+"";
			return res;
		}

		private static dynamic GetValue(dynamic value)
		{
			Type t=value.GetType();
			if(value is int || value is uint || value is short || value is ushort || value is long || value is ulong || value is float || value is double)
				return "'"+value.ToString()+"'";
			else if(value is byte)
				return "'"+value.ToString("X")+"'";
			else if(value is DateTime)
				return "'"+(value.Ticks / TimeSpan.TicksPerSecond).ToString()+"'";
			else if(value is Varray)
				return "'"+value.ToString()+"'";
			else if(t.Name.Contains("List") || t.Name.Contains("Dictionary"))
				return "'"+value.ToString()+"'";
			else if(value is object)
				return value.ToString();
			else
				return value.ToString();
		}



	}
}
