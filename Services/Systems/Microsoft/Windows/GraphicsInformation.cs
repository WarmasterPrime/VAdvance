using System;
using System.Management;

namespace VAdvance.Services.Systems.Microsoft.Windows
{
	public static class GraphicsInformation
	{
		public static readonly string Name;
		public static readonly string Status;
		public static readonly string Caption;
		public static readonly string DeviceId;
		public static readonly ulong AdapterRam;
		public static readonly string AdapterDACType;
		public static readonly bool Monochrome;
		public static readonly string[] InstalledDisplayDrivers;
		public static readonly string DriverVersion;
		public static readonly string VideoProcessor;
		public static readonly string VideoArchitecture;
		public static readonly string VideoMemoryType;

		static GraphicsInformation()
		{
			foreach(ManagementObject sel in new ManagementObjectSearcher("select * from Win32_VideoController").Get())
			{
				Name								=sel["Name"].ToString();
				Status								=sel["Status"].ToString();
				Caption								=sel["Caption"].ToString();
				DeviceId							=sel["DeviceID"].ToString();
				AdapterRam							=Convert.ToUInt64(sel["AdapterRAM"]);
				AdapterDACType						=sel["AdapterDACType"].ToString();
				Monochrome							=Convert.ToBoolean(sel["Monochrome"]);
				string tmp=sel["InstalledDisplayDrivers"].ToString();
				InstalledDisplayDrivers				=tmp.Contains(",") ? tmp.Split(',') : new string[] { tmp };
				DriverVersion						=sel["DriverVersion"].ToString();
				VideoProcessor						=sel["VideoProcessor"].ToString();
				VideoArchitecture					=ResponseConverter.Items.ContainsKey((int)sel["VideoArchitecture"]) ? ResponseConverter.Items[(int)sel["VideoArchitecture"]] : sel["VideoArchitecture"].ToString();
				VideoMemoryType						=ResponseConverter.Items.ContainsKey((int)sel["VideoMemoryType"]) ? ResponseConverter.Items[(int)sel["VideoMemoryType"]] : sel["VideoMemoryType"].ToString();
				break;
			}
		}
	}
}
