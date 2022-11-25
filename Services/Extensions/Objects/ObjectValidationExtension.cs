using System.Linq;

namespace VAdvance.Services.Extensions.Objects
{
	public static class ObjectValidationExtension
	{

		private static readonly string[] NumericDataTypes={
			"byte",
			"uint16","int16",
			"uint32","int32",
			"uing64","int64",
			"single","double"
		};

		public static bool CheckValue(this object value)
		{
			return (value!=null) && (value.GetType().Name.Contains("Dictionary") || value.GetType().Name.Contains("List")) ? ((dynamic)value).Count>0 : (value.GetType().Name=="String" &&(!string.IsNullOrEmpty((string)value))&&((string)value).Trim().Length>0);
		}

		public static bool IsNumeric(this object value)
		{
			return NumericDataTypes.Contains(value.GetType().Name.ToLower());
		}

	}
}
