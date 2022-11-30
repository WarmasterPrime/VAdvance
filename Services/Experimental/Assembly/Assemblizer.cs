using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VAdvance.Services.Extensions.Strings;

namespace VAdvance.Services.Experimental.Assembly
{
	public class Assemblizer
	{


		[SuppressUnmanagedCodeSecurity]
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int AssemblyAddFunction(int x, int y);

		//[SuppressUnmanagedCodeSecurity]
		//[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		//private delegate IntPtr AssemblyReadRegistersFunction();

		[DllImport("Kernel32.dll")]
		private static extern bool VirtualProtectEx(IntPtr h_proc, IntPtr lp_addr, UIntPtr dw_size, uint fl_new_protect, out uint lp_fl_old_protect);



		public static byte[] Compile(string value)
		{
			byte[] res=new byte[] { };
			if(value.CheckValue())
			{
				string[] lines=value.Split('\n');
				foreach(string line in lines)
				{
					//string[] reg=GetCaptures(Regex.Match(line,"^([A-z0-9]+)[\\s]*([^\\,\\s]*)").Captures);
					//string[] reg=GetCaptures(Regex.Match(line,"[\\,\\s]*([^\\,\\s]+)[\\,\\s]*").Captures);
					//string op_code=reg[0];
					//string[] param_list=GetCapturesStartFrom(reg);
				}
			}
			return res;
		}

		private static byte ToAsm(string value)
		{
			switch(value)
			{
				case "mov":
					return 0x8B;
				case "ebp":
					return 0x55;
				case "esp":
					return 0xE5;
				case "eax":
					return 0x45;
				case "edx":
					return 0x68;
				default:
					return 0x00;
			}
		}




		private static string[] GetCaptures(CaptureCollection collection)
		{
			string[] res={ };
			foreach(Capture c in collection)
			{
				Array.Resize(ref res,res.Length+1);
				res[res.Length-1]=c.Value;
			}
			return res;
		}

		private static string[] GetCapturesStartFrom(string[] list,int start=1)
		{
			string[] res={ };
			int i=0;
			foreach(string sel in list)
			{
				if(i>start)
				{
					Array.Resize(ref res,res.Length+1);
					res[res.Length-1]=sel;
				}
				i++;
			}
			return res;
		}



		public static int Add(int first=10, int second=-15)
		{
			Process proc=Process.GetCurrentProcess();
			int res;
			/*
			byte[] l={
				0x55,
				0x8B, 0x45, 0x08,
				0x8B, 0x55, 0x0C,
				0x01, 0xD0,
				0x5D,
				0xC3
			};
			*/
			/*
			byte[] l={
				0x55,
				0x89, 0xE5,
				0x8B, 0x45, 0x0C,
				0x8B, 0x55, 0x08,
				0x01, 0xD0,
				0x89, 0xEC,
				0x5D,
				0xC3
			};
			*/
			byte[] l={
				0x55,					// push ebp
				//0x89, 0xE5,				// mov ebp, esp
				0x8B, 0x45, 0x08,		// mov eax, [ebp+8]
				0x8B, 0x55, 0x0C,		// mov edx, [ebp+12]
				0x03, 0xD0,				// add eax, edx
				//0x89, 0xEC,				// mov esp, ebp
				0x8F, 0x5D,					// pop ebp
				0xC3					// return value
			};

			unsafe
			{
				fixed(byte* ptr=l)
				{
					IntPtr ma=(IntPtr)ptr;
					if(!VirtualProtectEx(proc.Handle, ma, (UIntPtr)l.Length, 0x40, out uint _))
						throw new Exception("Failed to validate parameters!");
					AssemblyAddFunction f=Marshal.GetDelegateForFunctionPointer<AssemblyAddFunction>(ma);
					res=f(first,second);
				}
			}
			return res;
		}





	}
}
