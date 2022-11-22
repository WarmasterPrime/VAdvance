using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Microsoft.Win32;
using VAdvance.Services.Extensions.Arrays;

namespace VAdvance.DataTypes.Arrays
{
	public class array : IEnumerable
	{
		private dynamic[] _Keys={ };
		private dynamic[] _Values={ };
		private  Type KeyType;
		private Type ValueType;
		private string _Type;

		public dynamic[] Keys
		{
			get
			{
				return _Keys;
			}
		}

		public dynamic[] Values
		{
			get
			{
				return _Values;
			}
		}

		public array()
		{

		}

		public dynamic this[dynamic key]
		{
			get
			{
				return ContainsKey(key) ? _Values[key] : null;
			}
			set
			{
				if(ContainsKey(key))
					_Values[key] = value;
				else
				{
					Array.Resize(ref _Keys, _Keys.Length+1);
					Array.Resize(ref _Values, _Values.Length+1);
					_Keys[_Keys.Length-1]=key;
					_Values[_Values.Length-1]=value;
				}
			}
		}

		public bool ContainsKey(dynamic key)
		{
			return (key!=null) && _Keys.Any((item)=>item==key);
		}

		public bool ContainsValue(dynamic value)
		{
			return (value!=null) && _Values.Any((item)=>item==value);
		}

		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
