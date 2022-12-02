using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using VAdvance.DataTypes.Enumerable;
using VAdvance.Services.Extensions.Strings;
using VAdvance.Services.Systems.EventHandlers;

namespace VAdvance.Services.Processing.Software
{
	public class VProcess : Process
	{
		private string _Path;
		private new bool Exited=false;
		private bool Running=false;
		private string[] Output={ };
		private Process Proc;
		private string[] _Paths;
		/// <summary>
		/// Gets or sets a list of targets (target files) that are to be executed/run.
		/// </summary>
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
		/// <summary>
		/// Gets or sets the target file path that is to be executed/run.
		/// </summary>
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
		/// <summary>
		/// A string consisting of the command-line arguments to be sent to the executing process.
		/// </summary>
		public string Arguments;
		public event DataReceivedEventHandler RedirectOutput;
		public event ProcessOutputEventHandler RedirectRawOutput;
		public new event VProcessDisposalEventHandler Disposed;
		public new bool WaitForExit=true;
		public bool UseShellExecute=false;
		public static readonly List<VProcess> Procs=new List<VProcess>();
		public readonly Process Current=GetCurrentProcess();
		/// <summary>
		/// Creates a new instance of a VProcess class object.
		/// </summary>
		public VProcess() { }

		private bool Contains(string name)
		{
			if(name.CheckValue())
			{

			}
			return false;
		}

		/// <summary>
		/// Shutsdown and releases all resources and operations that the process is utilizing.
		/// </summary>
		public new void Dispose()
		{
			if(Running || !Exited)
			{
				Proc.Close();
				Proc.Dispose();
			}
		}
		/// <summary>
		/// Disposes all process instances (Useful for mass process termination in situations such as application termination).
		/// </summary>
		public static void DisposeAll()
		{
			foreach(VProcess sel in Procs)
				sel.Dispose();
		}
		/// <summary>
		/// Executes all valid program files within a given array of paths.
		/// </summary>
		/// <returns></returns>
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
		/// <summary>
		/// Starts execution of a file asynchronously.
		/// </summary>
		/// <returns></returns>
		public async Task<dynamic> Execute()
		{
			if(Path!=null)
			{
				if(!UseShellExecute)
				{
					RedirectOutput=RedirectRawOutput==null ? RedirectOutput??Proc_OutputDataReceived : Proc_OutputDataReceived;
					UseShellExecute=RedirectRawOutput==null ? RedirectOutput==null : false;
				}
				Proc=new Process
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
					Proc.StartInfo.Arguments=Arguments;
				Proc.Exited+=Proc_Exited;
				if(!UseShellExecute)
				{
					Proc.OutputDataReceived+=RedirectOutput;
					Proc.ErrorDataReceived+=RedirectOutput;
				}
				Exited=false;
				Proc.Start();
				Procs.Add(this);
				if(!UseShellExecute)
				{
					Proc.BeginOutputReadLine();
					Proc.BeginErrorReadLine();
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
