using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAdvance.Services.Extensions.Types
{
	public static class TypeValidationExtension
	{

		/// <summary>
		/// Determines if the data-type is similar to the value's data-type.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsSimilar(this object value, Type compared_to)
		{
			if(compared_to!=null)
			{
				Type t=value.GetType();
				return (compared_to.IsArray ? compared_to.Name.Replace("[]","") : compared_to.Name).Equals(t.IsArray ? t.Name.Replace("[]","") : t.Name);
			}
			return false;
		}
		/// <summary>
		/// Determines if the data-type of the value is numerical.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsNumeric(this Type value)
		{
			return (value!=null) && value.IsPrimitive && TypeNames.NumericTypes.Contains(value.Name.ToLower());
		}

	}
}
