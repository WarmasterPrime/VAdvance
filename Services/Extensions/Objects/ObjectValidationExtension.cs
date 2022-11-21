using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAdvance.Services.Extensions.Objects
{
	public static class ObjectValidationExtension
	{

		public static bool CheckValue(this object value)
		{
			return (value!=null) && (value.GetType().Name.Contains("Dictionary") || value.GetType().Name.Contains("List")) ? ((dynamic)value).Count>0 : (value.GetType().Name=="String" &&(!string.IsNullOrEmpty((string)value))&&((string)value).Trim().Length>0);
		}

	}
}
