using System;
using VAdvance.Services.Sorting;

namespace VAdvance.Services.Extensions.Arrays
{
	public static class ArrayModificationExtension
	{
		public static dynamic[] Push(this dynamic[] obj,dynamic value)
		{
			if((obj!=null) && obj.GetType().FullName.Contains(value.GetType().Name))
			{
				Array.Resize(ref obj,obj.Length+1);
				obj[obj.Length-1]=value;
			}
			return obj;
		}

		

	}
}
