using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAdvance.Services.Systems.Microsoft.Windows
{
	public class StorageDriveItem
	{
		private DriveInfo DriveData;
		public bool Ready
		{
			get
			{
				return (DriveData!=null) && DriveData.IsReady;
			}
		}
		public string Name
		{
			get
			{
				return Ready ? DriveData.Name : null;
			}
		}
		public DriveType Type
		{
			get
			{
				return Ready ? DriveData.DriveType : DriveType.Unknown;
			}
		}
		public string Label
		{
			get
			{
				return Ready ? DriveData.VolumeLabel : null;
			}
		}
		public StorageDriveFormatTypes Format
		{
			get
			{
				if(Ready)
					switch(DriveData.DriveFormat)
					{
						case "NTFS":
							return StorageDriveFormatTypes.NTFS;
						case "FAT32":
							return StorageDriveFormatTypes.FAT32;
						default:
							return StorageDriveFormatTypes.Unknown;
					}
				return StorageDriveFormatTypes.None;
			}
		}
		public ulong AvailableFreeSpace
		{
			get
			{
				return Ready ? (ulong)DriveData.AvailableFreeSpace : 0;
			}
		}
		public ulong TotalFreeSpace
		{
			get
			{
				return Ready ? (ulong)DriveData.TotalFreeSpace : 0;
			}
		}
		public ulong TotalSize
		{
			get
			{
				return Ready ? (ulong)DriveData.TotalSize : 0;
			}
		}
		public string RootDirectory
		{
			get
			{
				return Ready ? DriveData.RootDirectory.FullName : null;
			}
		}

		public StorageDriveItem(DriveInfo item)
		{
			DriveData=item;
		}

	}
}
