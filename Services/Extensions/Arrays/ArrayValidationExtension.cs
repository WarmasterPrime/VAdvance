using System;

namespace VAdvance.Services.Extensions.Arrays
{
	public static class ArrayValidationExtension
	{
		/// <summary>
		/// Determines if the array is valid for use.
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public static bool CheckValue(this object[] array)
		{
			return (array!=null)&&array.Length>0;
		}
	}
}
