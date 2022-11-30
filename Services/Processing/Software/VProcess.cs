using System;
using System.Diagnostics;
using System.Threading.Tasks;
using VAdvance.DataTypes.Enumerable;
using VAdvance.Services.Extensions.Strings;
using VAdvance.Services.System.EventHandlers;

namespace VAdvance.Services.Processing.Software
{
	public class VProcess
	{

		private string _Path;
		private string[] _Paths;
		public string[] Paths
		{
			get
			{
				return _Paths;
			}
			set
			{
				_Paths=(value!=null) && value.Length>0 ? value : null;
			}
		}

		public string Path
		{
			get
			{
				return _Path;
			}
			set
			{
				_Path=value.IsFile() ? value : null;
			}
		}
		public string Arguments;
		private bool Exited=false;
		private bool Running=false;
		private string[] Output={ };
		public event DataReceivedEventHandler RedirectOutput;
		public event ProcessOutputEventHandler RedirectRawOutput;
		public bool WaitForExit=true;
		public bool UseShellExecute=false;

		public VProcess()
		{

		}

		public async Task<Varray> ExecuteAll()
		{
			Varray res=new Varray();
			if((_Paths!=null)&&_Paths.Length>0)
				foreach(string item in _Paths)
					if(item.IsFile())
					{
						VProcess ins = new VProcess
						{
							Path=item,
							Arguments=Arguments,
							WaitForExit=WaitForExit,
							RedirectOutput=RedirectOutput,
							RedirectRawOutput=RedirectRawOutput
						};
						if(RedirectRawOutput==null)
							res.Add(await ins.Execute());
					}
			return res;
		}

		public async Task<dynamic> Execute()
		{
			if(Path!=null)
			{
				if(!UseShellExecute)
				{
					RedirectOutput=RedirectRawOutput==null ? RedirectOutput??Proc_OutputDataReceived : Proc_OutputDataReceived;
					UseShellExecute=RedirectRawOutput==null ? RedirectOutput==null : false;
				}
				Process proc=new Process
				{
					EnableRaisingEvents=true,
					StartInfo={
						UseShellExecute=UseShellExecute,
						RedirectStandardOutput=!UseShellExecute,
						RedirectStandardError=!UseShellExecute,
						FileName=Path
					}
				};
				if(Arguments!=null)
					proc.StartInfo.Arguments=Arguments;
				proc.Exited+=Proc_Exited;
				if(!UseShellExecute)
				{
					proc.OutputDataReceived+=RedirectOutput;
					proc.ErrorDataReceived+=RedirectOutput;
				}
				Exited=false;
				proc.Start();
				if(!UseShellExecute)
				{
					proc.BeginOutputReadLine();
					proc.BeginErrorReadLine();
				}
				Running=true;
				if(WaitForExit)
				{
					await WaitForProgramExit();
					return Output;
				}
			}
			return null;
		}

		private void Proc_OutputDataReceived(object sender,DataReceivedEventArgs e)
		{
			if(RedirectRawOutput==null)
			{
				Array.Resize(ref Output,Output.Length+1);
				Output[Output.Length-1]=e.Data;
			}
			else
				RedirectRawOutput(sender,e.Data);
		}

		private async Task<bool> WaitForProgramExit()
		{
			while(!Exited || Running)
				await Task.Delay(5);
			return true;
		}

		private void Proc_Exited(object sender,EventArgs e)
		{
			Exited=true;
			Running=false;
		}
	}
}
