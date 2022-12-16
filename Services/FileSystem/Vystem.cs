using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAdvance.DataTypes.Enumerable;
using VAdvance.Services.Extensions.Strings;

namespace VAdvance.Services.FileSystem
{
	public class Vystem
	{
		private string _Path;
		public string Path
		{
			get
			{
				return _Path;
			}
			set
			{
				_Path=value.CheckPath() ? value : null;
			}
		}
		private ulong _Size;
		public ulong Size { get { return _Size; } }
		public readonly Varray Items=new Varray();


		public Vystem(string path)
		{
			Path=path;
		}

		private async void GetAllDirItems()
		{
			if(Path.IsDir())
			{
				Varray res=new Varray();

			}
		}

		public static async Task<List<string>> AsyncScan(string path)
		{
			//List<string> res=new List<string>();
			//return res.ToArray();
			return await GetDirectoryItems(path);
		}

		private static async Task<List<string>> GetDirectoryItems(string path)
		{
			List<string>res=new List<string>();
			try
			{
				if(path.IsDir())
				{
					List<string> l=Directory.GetDirectories(path).ToList();
					l.AddRange(Directory.GetFiles(path));
					foreach(string s in l)
						res.AddRange(await GetDirectoryItems(s));
				}
				else if(path.IsFile())
					res.Add(path);
			}
			catch { }
			return res;
		}


		/*
		private static async Task<Varray> AsyncScanDir(string path)
		{
			Varray res=new Varray();
			List<string> l=new List<string>();
			l.AddRange(Directory.GetDirectories(path));
			List<string> f=new List<string>();
			f.AddRange(Directory.GetFiles(path));
			foreach(string sel in l)
			{
				res.Add(sel);
			}
		}
		*/



	}
}
