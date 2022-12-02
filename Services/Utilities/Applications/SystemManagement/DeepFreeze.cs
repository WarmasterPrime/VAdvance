using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VAdvance.Services.Extensions.Strings;
using VAdvance.Services.Processing.Software;

namespace VAdvance.Services.Utilities.Applications.SystemManagement
{
	public class DeepFreeze
	{
		private string _Path="C:\\Windows\\sysWOW64\\DFC.exe";
		private bool _Ready=false;
		private bool _IsFrozen=false;
		private string _Version;

		public bool Ready
		{
			get { return _Ready; }
		}
		public string Path
		{
			get { return _Path; }
			set
			{
				if(value.IsExecutable())
				{
					_Path=value;
					_Ready=true;
				}
				else
				{
					_Path=null;
					_Ready=false;
				}
			}
		}
		public string Password;
		public string Version{get{return _Version;}}
		public bool IsFrozen{get{return _IsFrozen;}}

		public DeepFreeze(string path=null, string password=null)
		{
			Path=path??Path;
			Password=password??Password;
			Task.Run(()=>GetInformation());
		}
		/// <summary>
		/// Gets and stores all of the persistent information from Deep Freeze.
		/// </summary>
		private async void GetInformation()
		{
			_Version=await GetVersion();
			_IsFrozen=!await IsThawed();
		}
		/// <summary>
		/// Thaws the system.
		/// </summary>
		/// <param name="restart">Indicates if the system should restart now (If the system is already thawed, the system will not restart).</param>
		/// <param name="flag">Specifies the boot option to conduct.</param>
		/// <returns></returns>
		public async Task<bool> Thaw(bool restart = false, DeepFreezeBootFlags flag=DeepFreezeBootFlags.None)
		{
			if(IsFrozen)
			{
				dynamic res=await Execute(Password + (restart ? " /BOOTTHAWED" : " /THAWNEXTBOOT") + (flag==DeepFreezeBootFlags.BootLocked ? "NOINPUT" : ""));
				return res is bool ? res : false;
			}
			return true;
		}
		/// <summary>
		/// Freezes the system.
		/// </summary>
		/// <param name="restart">Indicates if the system should restart now (If the system is already frozen, the system will not restart).</param>
		/// <param name="flag">Specifies the boot option to conduct.</param>
		/// <returns></returns>
		public async Task<bool> Freeze(bool restart = false, DeepFreezeBootFlags flag=DeepFreezeBootFlags.None)
		{
			if(!IsFrozen)
			{
				dynamic res=await Execute(Password + (restart ? " /BOOTFROZEN" : " /FREEZENEXTBOOT") + (flag==DeepFreezeBootFlags.BootLocked ? "NOINPUT" : ""));
				return res is bool ? res : false;
			}
			return true;
		}
		/// <summary>
		/// Prevents keyboard and mouse control on the system.
		/// </summary>
		public async void LockInput()
		{
			await Execute(Password+" /LOCK");
		}
		/// <summary>
		/// Allows keyboard and mouse control on the system.
		/// </summary>
		public async void UnlockInput()
		{
			await Execute(Password+" /UNLOCK");
		}
		/// <summary>
		/// Gets the Deep Freeze application version.
		/// </summary>
		/// <returns></returns>
		public async Task<string> GetVersion()
		{
			dynamic res=await Execute("get /version");
			return res is string ? res : null;
		}
		/// <summary>
		/// Gets the system state.
		/// </summary>
		/// <returns></returns>
		public async Task<string> GetState()
		{
			dynamic res=await Execute("get /ISFROZEN");
			return res is bool ? (res ? "FROZEN" : "THAWED") : "FROZEN0";
		}
		/// <summary>
		/// Determines if the system is thawed.
		/// </summary>
		/// <returns></returns>
		public async Task<bool> IsThawed()
		{
			return !(await Execute("get /ISFROZEN"));
		}
		/// <summary>
		/// Checks the path to determine if the path references a DeepFreeze executable.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static async Task<bool> CheckApplicationPath(string path)
		{
			if(path.IsExecutable())
			{
				string[] r=await new VProcess
				{
					Path=path,
					Arguments="get /version",
					CreateNoWindow=true
				}.Execute();
				return r.Length>0 && r.Any((a)=>Regex.IsMatch(a,"[0-9]+"));
			}
			return false;
		}
		/// <summary>
		/// Executes a Deep Freeze command.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public async Task<dynamic> Execute(string value)
		{
			if(Ready)
			{
				string[] res=await new VProcess
				{
					Arguments=value,
					Path=_Path,
					CreateNoWindow=true,
					IncludeExitCode=true
				}.Execute();
				if(res.Length>0)
					return ConvertValue(res[0]);
			}
			return null;
		}
		/// <summary>
		/// Converts the output value from Deep Freeze.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="UnauthorizedAccessException"></exception>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="Exception"></exception>
		private dynamic ConvertValue(string value)
		{
			switch(value)
			{
				case "0":
					return false;
				case "1":
					return true;
				case "2":
					throw new UnauthorizedAccessException("The current user does not possess administrative privileges.");
				case "3":
					throw new ArgumentException("The command provided/sent/queried was invalid on this installation of DeepFreeze.");
				case "4":
					throw new ArgumentException("The command provided was invalid.");
				case "5":
					throw new Exception("An internal error occurred while DeepFreeze attempted to process the command.");
				default:
					return value;
			}
		}



	}
}
