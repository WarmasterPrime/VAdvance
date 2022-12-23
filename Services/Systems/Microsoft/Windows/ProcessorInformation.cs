using System;
using System.Management;

namespace VAdvance.Services.Systems.Microsoft.Windows
{
	public static class ProcessorInformation
	{
		public static readonly int ProcessorCount				=Environment.ProcessorCount;
		public static readonly int Architecture					=Environment.Is64BitOperatingSystem ? 64 : 32;
		public static readonly string Manufacturer;
		public static readonly string Name;
		public static readonly int CurrentClockSpeed;
		public static readonly string Caption;
		public static readonly int CoreCount;
		public static readonly int EnabledCores;
		public static readonly int LogicalProcessorCount;
		public static readonly int Family;
		public static readonly string Type;
		public static readonly int AddressWidth;
		public static readonly string DeviceId;

		static ProcessorInformation()
		{
			foreach(ManagementObject sel in new ManagementObjectSearcher("select * from Win32_Processor").Get())
			{
				Manufacturer			=sel["Manufacturer"].ToString();
				Name					=sel["Name"].ToString();
				CurrentClockSpeed		=(int)sel["CurrentClockSpeed"];
				Caption					=sel["Caption"].ToString();
				CoreCount				=(int)sel["NumberOfCores"];
				EnabledCores			=(int)sel["NumberOfEnabledCore"];
				LogicalProcessorCount	=(int)sel["NumberOfLogicalProcessors"];
				Family					=(int)sel["Family"];
				Type					=ResponseConverter.Items.ContainsKey((int)sel["ProcessorType"]) ? ResponseConverter.Items[(int)sel["ProcessorType"]] : sel["ProcessorType"].ToString();
				AddressWidth			=(int)sel["AddressWidth"];
				DeviceId				=sel["DeviceID"].ToString();
				break;
			}
		}
	}
}
