using System;

namespace VAdvance.Services.Extensions.Arrays
{
	public static class ArrayModificationExtension
	{
		/// <summary>
		/// Adds an element to the array list.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int[] Push(this int[] obj,int value)
		{
			if(obj!=null)
			{
				Array.Resize(ref obj,obj.Length+1);
				obj[obj.Length-1]=value;
			}
			return obj;
		}
		/// <summary>
		/// Adds an element to the array list.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static double[] Push(this double[] obj,double value)
		{
			if(obj!=null)
			{
				Array.Resize(ref obj,obj.Length+1);
				obj[obj.Length-1]=value;
			}
			return obj;
		}
		/// <summary>
		/// Adds an element to the array list.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static float[] Push(this float[] obj,float value)
		{
			if(obj!=null)
			{
				Array.Resize(ref obj,obj.Length+1);
				obj[obj.Length-1]=value;
			}
			return obj;
		}
		/// <summary>
		/// Adds an element to the array list.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static uint[] Push(this uint[] obj,uint value)
		{
			if(obj!=null)
			{
				Array.Resize(ref obj,obj.Length+1);
				obj[obj.Length-1]=value;
			}
			return obj;
		}
		/// <summary>
		/// Adds an element to the array list.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static byte[] Push(this byte[] obj,byte value)
		{
			if(obj!=null)
			{
				Array.Resize(ref obj,obj.Length+1);
				obj[obj.Length-1]=value;
			}
			return obj;
		}
		/// <summary>
		/// Adds an element to the array list.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static ushort[] Push(this ushort[] obj,ushort value)
		{
			if(obj!=null)
			{
				Array.Resize(ref obj,obj.Length+1);
				obj[obj.Length-1]=value;
			}
			return obj;
		}
		/// <summary>
		/// Adds an element to the array list.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static short[] Push(this short[] obj,short value)
		{
			if(obj!=null)
			{
				Array.Resize(ref obj,obj.Length+1);
				obj[obj.Length-1]=value;
			}
			return obj;
		}
		/// <summary>
		/// Adds an element to the array list.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static ulong[] Push(this ulong[] obj,ulong value)
		{
			if(obj!=null)
			{
				Array.Resize(ref obj,obj.Length+1);
				obj[obj.Length-1]=value;
			}
			return obj;
		}
		/// <summary>
		/// Adds an element to the array list.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static long[] Push(this long[] obj,long value)
		{
			if(obj!=null)
			{
				Array.Resize(ref obj,obj.Length+1);
				obj[obj.Length-1]=value;
			}
			return obj;
		}
		/// <summary>
		/// Adds an element to the array list.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static object[] Push(this object[] obj,object value)
		{
			if(obj!=null)
			{
				Array.Resize(ref obj,obj.Length+1);
				obj[obj.Length-1]=value;
			}
			return obj;
		}
		/// <summary>
		/// Adds an element to the array list.
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static char[] Push(this char[] obj,char value)
		{
			if(obj!=null)
			{
				Array.Resize(ref obj,obj.Length+1);
				obj[obj.Length-1]=value;
			}
			return obj;
		}
	}
}
