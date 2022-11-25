using System;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace VAdvance.DataTypes.Arrays
{
	public class array : IEnumerable
	{
		private dynamic[] _Keys={ };
		private dynamic[] _Values={ };
		private bool IsAssociative
		{
			get
			{
				return _Keys.Length>0 ? !Regex.IsMatch(_Keys.GetType().Name.ToLower(),"(int|long|short|byte|float|double)") : false;
			}
		}
		public int Count
		{
			get
			{
				return Math.Min(_Keys.Length,_Values.Length);
			}
		}
		public int Length
		{
			get
			{
				return Count;
			}
		}
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
		/// <summary>
		/// Gets or Sets a given value at a specified index/location within the array.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public dynamic this[dynamic key]
		{
			get
			{
				return ContainsKey(key) ? _Values[key] : null;
			}
			set
			{
				if(ContainsKey(key))
					_Values[IndexOf(key)]=value;
				else
					Add(key,value);
			}
		}
		/// <summary>
		/// Appends a new value to the end of the array.
		/// </summary>
		/// <param name="value"></param>
		public void Add(dynamic value)
		{
			Push(value);
		}
		/// <summary>
		/// Appends a new key-value pair to the end of the array.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public void Add(dynamic key,dynamic value)
		{
			Push(key,value);
		}
		/// <summary>
		/// Adds a new value at the end of the array.
		/// </summary>
		/// <param name="value"></param>
		public void Push(dynamic value)
		{
			if((value!=null) && value.GetType() is _Type && !IsAssociative)
			{
				Array.Resize(ref _Values,_Values.Length+1);
				_Values[_Values.Length-1]=value;
				RebuildKeys();
			}
		}
		/// <summary>
		/// Adds a new key and value at the end of the array.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public void Push(dynamic key,dynamic value)
		{
			if(value!=null && key!=null)
			{
				Array.Resize(ref _Keys, _Keys.Length+1);
				Array.Resize(ref _Values, _Values.Length+1);
				_Keys[_Keys.Length-1]=key;
				_Values[_Values.Length-1]=value;
			}
		}
		/// <summary>
		/// Determines if a given key is present within the array.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool ContainsKey(dynamic key)
		{
			return (key!=null) && _Keys.Any((item)=>item==key);
		}
		/// <summary>
		/// Determines if a given value is present within the array.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool ContainsValue(dynamic value)
		{
			return (value!=null) && _Values.Any((item)=>item==value);
		}
		/// <summary>
		/// Removes all instances of a given value.
		/// </summary>
		/// <param name="value"></param>
		public void Remove(dynamic value)
		{
			if(value!=null)
			{
				dynamic[] tmp={ };
				dynamic[] key_tmp={ };
				if(IsAssociative)
				{
					int i=0;
					foreach(dynamic sel in _Keys)
					{
						if(!sel.Equals(value))
						{
							Array.Resize(ref tmp,tmp.Length+1);
							tmp[tmp.Length-1]=_Values[i];
							Array.Resize(ref key_tmp,key_tmp.Length+1);
							key_tmp[key_tmp.Length-1]=sel;
						}
						i++;
					}
					_Keys=key_tmp;
				}
				else
				{
					foreach(dynamic sel in _Values)
						if(!sel.Equals(value))
						{
							Array.Resize(ref tmp,tmp.Length+1);
							tmp[tmp.Length-1]=sel;
						}
					RebuildKeys();
				}
				_Values=tmp;
			}
		}
		/// <summary>
		/// Rebuilds the key array if the array type is non-associative.
		/// </summary>
		private void RebuildKeys()
		{
			if(!IsAssociative)
			{
				int[] tmp={ };
				for(int i = 0;i<_Values.Length;i++)
				{
					Array.Resize(ref tmp,tmp.Length+1);
					tmp[tmp.Length-1]=i;
				}
			}
		}
		/// <summary>
		/// Finds the first occurrence/instance of a given key or value within the array.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>the <see cref="int">index</see> within an array OR the <see cref="dynamic">key</see> where the <paramref name="value"/> was found at.</returns>
		public int IndexOf(dynamic value)
		{
			if(value!=null)
			{
				int i=0;
				if(IsAssociative)
					foreach(dynamic sel in _Values)
					{
						if(sel.Equals(value))
							return _Keys[i];
						i++;
					}
				else
					foreach(dynamic sel in _Values)
					{
						if(sel.Equals(value))
							return i;
						i++;
					}
			}
			return -1;
		}
		/// <summary>
		/// Generates a JSON equivalent of the array data.
		/// </summary>
		/// <returns>a <see cref="string">JSON</see> string representing the items within the array.</returns>
		public override string ToString()
		{
			string res="";
			if(IsAssociative)
			{
				for(int i = 0;i<Count;i++)
					res+=(i>0 ? "," : "") + GetValueString(_Keys[i]) + ":" + GetValueString(_Values[i]);
				return "{"+res+"}";
			}
			var dev=_Values;
			for(int i = 0;i<Count;i++)
				res+=(i>0 ? "," : "") + GetValueString(_Values[i]);
			return "["+res+"]";
		}
		/// <summary>
		/// Generates a string/JSON safe equivalent of the value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static string GetValueString(dynamic value)
		{
			return value!=null ? (value is string ? "\""+value+"\"" : value.ToString()) : "null";
		}

<<<<<<< HEAD








=======
>>>>>>> master
		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
