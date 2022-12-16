using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAdvance.Services.Extensions.Strings;

namespace VAdvance.Services.FileSystem.Security
{
	public class VScanner
	{

		public static async Task<bool> Scan(string path)
		{
			if(path.IsFile())
			{
				FileStream fs=File.OpenRead(path);
				long len=fs.Length;
				byte[] data=new byte[len];
				fs.Read(data,0,data.Length);
				fs.Close();
			}
			return false;
		}





	}
}
