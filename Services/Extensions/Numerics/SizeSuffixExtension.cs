using System;

namespace VAdvance.Services.Extensions.Numerics
{
	public static class SizeSuffixExtension
	{

		private static readonly string[] Suffixes={"bytes","KB","MB","GB","TB","PB","EB","ZB","YB" };

		public static string GetSizeSuffix(this long value)
		{
			return SizeConvert(value);
		}

		public static string GetSizeSuffix(this ulong value)
		{
			return SizeConvert(value);
		}

		public static string GetSizeSuffix(this uint value)
		{
			return SizeConvert(value);
		}

		public static string GetSizeSuffix(this int value)
		{
			return SizeConvert(value);
		}

		public static string GetSizeSuffix(this ushort value)
		{
			return SizeConvert(value);
		}

		public static string GetSizeSuffix(this short value)
		{
			return SizeConvert(value);
		}

		public static string GetSizeSuffix(this byte value)
		{
			return SizeConvert(value);
		}

		public static string GetSizeSuffix(this double value)
		{
			return SizeConvert(value);
		}

		public static string GetSizeSuffix(this float value)
		{
			return SizeConvert(value);
		}

		public static string GetSizeSuffix(this decimal value)
		{
			return SizeConvert(value);
		}

		private static string SizeConvert(dynamic value)
		{
			if(value.GetType().IsNumeric())
			{
				int mag=(int)Math.Log(value,1024);
				return string.Format("{0:n1} {1}",(decimal)value / (1L << (mag * 10)),Suffixes[mag]);
			}
			return value.ToString();
		}
	}
}
