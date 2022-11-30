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
