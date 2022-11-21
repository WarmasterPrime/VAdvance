using System;
using System.Collections.Generic;
using System.Linq;

namespace VAdvance.Services.Extensions.Arrays
{
	public static class ArrayValidationExtension
	{
		/// <summary>
		/// Determines if the array is valid for use.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool CheckValue(this object[] obj)
		{
			return (obj!=null)&&obj.Length>0;
		}
		/// <summary>
		/// Determines if the dictionary set is valid and usable.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool CheckValue(this Dictionary<dynamic,dynamic> value)
		{
			return (value!=null)&&value.Count>0;
		}
		/// <summary>
		/// Determines if the list set is valid and usable.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool CheckValue(this List<dynamic> value)
		{
			return (value!=null)&&value.Count>0;
		}
		/// <summary>
		/// Checks if the array contains the specified value.
		/// </summary>
		/// <param name="obj">The array to search in.</param>
		/// <param name="value">THe value to search for within the array.</param>
		/// <returns><see cref="bool">true</see> if the array contains the specified value, <see cref="bool">false</see> otherwise.</returns>
		public static bool Contains(this dynamic[] obj,dynamic value)
		{
			return obj!=null && value!=null ?? obj.Any((item)=>item==value);
		}




	}
}
