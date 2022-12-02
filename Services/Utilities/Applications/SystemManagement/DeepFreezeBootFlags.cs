using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAdvance.Services.Utilities.Applications.SystemManagement
{
	public enum DeepFreezeBootFlags
	{
		None=0x0,
		Normal=0x1,
		BootLocked=0x2,
		BootUnlocked=0x3
	}
}
