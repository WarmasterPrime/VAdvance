using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VAdvance.Services.Extensions.Strings;
using VAdvance.Services.Systems.Informational.FileSystem;
using NAudio;
using NAudio.Codecs;
using NAudio.CoreAudioApi;
using NAudio.Utils;
using NAudio.FileFormats;
using AxWMPLib;

namespace VAdvance.Services.Systems.Readers.Audio
{
	public class AudioReader
	{
		private string _Path;
		private string _Title;
		private AudioFormat _Format=AudioFormat.None;
		private long _Length;
		private string[] _Brands;
		private string _EncoderSettings;
		private string _MajorBrand;
		private string _MinorBrand;
		private string _MinorVersion;
		private string _MetaData;
		private string _Data;
		private ulong _LineCount=0;
		private string[] _Lines;
		private AxWindowsMediaPlayer _AudioPlayerControl;
		public AxWindowsMediaPlayer AudioPlayerControl{ get { return _AudioPlayerControl; } set { _AudioPlayerControl=value; } }

		public string Path
		{
			get { return _Path; }
			set
			{
				_Path = value;
			}
		}
		public string Title { get { return _Title; }}
		public AudioFormat Format { get { return _Format; }}
		public long Length { get { return _Length; }}
		public string[] Brands { get { return _Brands; }}
		public string EncoderSettings { get { return _EncoderSettings; }}
		public string MajorBrand { get { return _MajorBrand; }}
		public string MinorBrand { get { return _MinorBrand; }}
		public string MinorVersion { get { return _MinorVersion; }}
		public string MetaData { get { return _MetaData; }}
		public string Data { get { return _Data; }}
		public ulong LineCount { get { return (ulong)_Lines.LongLength; }}
		public string[] Lines { get { return _Lines; }}


		public AudioReader()
		{

		}

		public void StartReading()
		{
			if(_Path.GetExtension()=="mp3")
			{

			}
		}

		private void GetFileContent()
		{
			foreach(string line in File.ReadLines(Path))
			{
				_Data+=line;
				Array.Resize(ref _Lines, _Lines.Length+1);
				_Lines[_Lines.Length-1]=line;
			}
		}

		public string GetFormat()
		{
			string res="";
			foreach(char c in Lines[0])
			{
				if(c==4)
					break;
				res+=c;
			}
			return res;
		}

		public string GetMajorBrand()
		{
			string reg="major_brand\x00([A-z0-9\\-\\.\\,_]+)\x00";
			return Regex.IsMatch(Lines[0],reg) ? Regex.Match(Lines[0],reg).Captures[1].Value : null;
		}

		private void Dev()
		{

		}

		











	}
}
