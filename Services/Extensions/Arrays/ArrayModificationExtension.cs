using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAdvance.Services.Extensions.Arrays
{
	public static class ArrayModificationExtension
	{

		public static dynamic Push(this object[] array,dynamic value)
		{
			if(array.GetType().FullName.Contains(value.GetType().Name))
			{
				Array.Resize(ref array,array.Length+1);
				array[array.Length-1]=value;
			}
			return array;
		}

	}
}
