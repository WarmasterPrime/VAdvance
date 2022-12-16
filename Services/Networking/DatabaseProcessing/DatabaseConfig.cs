using VAdvance.Services.Extensions.Arrays;
using VAdvance.Services.Extensions.Strings;

namespace VAdvance.Services.Networking.DatabaseProcessing
{
	public class DatabaseConfig
	{
		private string _Username;
		private string _Password;
		private string _DatabaseName;
		private string _Host;
		private uint _Port=1433;
		private string _ConnectionString;
		private DatabaseTypeFlags _DatabaseType=DatabaseTypeFlags.Sql;
		public string Host
		{
			get{return _Host;}
			set
			{
				_Host=value.CheckValue() ? value : null;
				PrepConnectionString();
			}
		}
		public uint Port
		{
			get{return _Port;}
			set
			{
				_Port=value>0&&value<65535 ? value : _Port;
			}
		}
		public string Username
		{
			get{return _Username;}
			set
			{
				_Username=value;
				PrepConnectionString();
			}
		}
		public string Password
		{
			get { return _Password; }
			set
			{
				_Password=value;
				PrepConnectionString();
			}
		}
		public string DatabaseName
		{
			get{return _DatabaseName;}
			set
			{
				_DatabaseName = value;
				PrepConnectionString();
			}
		}
		public string TableName;
		public string ConnectionString{get{return _ConnectionString;}}
		private void PrepConnectionString()
		{
			if((new string[] { Host,Username,Password,DatabaseName }).CheckValues())
				if(_DatabaseType==DatabaseTypeFlags.Sql)
					_ConnectionString="Data Source="+Host+";Initial Catalog="+DatabaseName+";Persist Security Info=True;User ID="+Username+";Password="+Password+";";
		}
	}
}
