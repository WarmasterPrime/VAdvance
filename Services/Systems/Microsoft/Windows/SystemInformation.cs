using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAdvance.Services.Systems.Microsoft.Windows
{
	public static class SystemInformation
	{

		public static readonly string Name						=Environment.MachineName;
		public static readonly string PlatformName				=Environment.OSVersion.Platform.ToString();
		public static readonly int MajorVersion					=Environment.OSVersion.Version.Major;
		public static readonly int MinorVersion					=Environment.OSVersion.Version.Minor;
		//public static readonly 

	}
}
