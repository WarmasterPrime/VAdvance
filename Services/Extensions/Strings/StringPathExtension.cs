using System.IO;
using System.Linq;
using VAdvance.Services.Extensions.Strings.Data.FileSystem;

namespace VAdvance.Services.Extensions.Strings
{
	public static class StringPathExtension
	{
		/// <summary>
		/// Determines if the string value references a valid and existing file or directory path on the system.
		/// </summary>
		/// <param name="value">Obtained from an instance of a string.</param>
		/// <returns><see cref="bool">true</see> upon success, <see cref="bool">false</see> otherwise.</returns>
		public static bool CheckPath(this string value)
		{
			return Directory.Exists(value)||File.Exists(value);
		}
		/// <summary>
		/// Determines if the string value references a valid and existing file path on the system.
		/// </summary>
		/// <param name="value">Obtained from an instance of a string.</param>
		/// <returns><see cref="bool">true</see> upon success, <see cref="bool">false</see> otherwise.</returns>
		public static bool IsFile(this string value)
		{
			return File.Exists(value);
		}
		/// <summary>
		/// Determines if the string value references a valid and existing directory path on the system.
		/// </summary>
		/// <param name="value">Obtained from an instance of a string.</param>
		/// <returns><see cref="bool">true</see> upon success, <see cref="bool">false</see> otherwise.</returns>
		public static bool IsDir(this string value)
		{
			return Directory.Exists(value);
		}
		/// <summary>
		/// Determines if the string references a valid and existing executable file.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsExecutable(this string value)
		{
			return value.IsFile() && Path.HasExtension(value) && FileExtensions.Executable.Contains(Path.GetExtension(value).ToLower());
		}
		/// <summary>
		/// Gets the file extension of a given path.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetExtension(this string value)
		{
			if(value.IsFile() && Path.HasExtension(value))
			{
				string e=Path.GetExtension(value).ToLower();
				int num=e.IndexOf('.');
				return e.Contains(".") ? e.Substring(num+1,e.Length-num-1) : e;
			}
			return value;
		}
	}
}
