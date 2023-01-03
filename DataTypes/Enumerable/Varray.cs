/*
* title:						Varray
* desc:							Provides the means to dynamically sustain a collection of items that can be converted into a JSON string based on its contents. Can provide a JSON string or array string.
								Useful for web-based projects that need to communicate between the client and web-server.
								Designed for holding large amounts of data.
* author:						Daniel K. Valente
* created:						11-25-2022
* modified:						12-29-2022
* version:						0.0.0.1
* features:
			- Automated data conversion between associative and non-associative collections.
			- Enumerable
			- Automated index association.
			- Version control: References to existing properties/fields eliminate the need to adjust source code.
* future:
			- Provide a means to compress the collective to reduce memory usage... The option to optimize memory consumption or optimize processing usage.
				- Basically, the developer may choose to focus on reducing memory usage at the cost of processing power, or may choose to focus on reduced processing power over memory usage.
			- Provide a means to support dynamic collection dimensions (Arrays and Lists are single dimensions, as Dictionaries are two-dimensional).
				- Basically, allows the developer to create and reference multi-dimensional arrays with ease without needing to specify a type or create new instances of arrays or collections.
			- Optimize efficiency by utilizing assembly-line language to improve processing efficiency and completion time.
			- Provide a means to generate new instances of an object or create new references to/of an object and instantiate only specific instances at specific indexes.
			- Implement value matching with operator overloads to provide a more advanced means to determine if two or more values match a given value.
			- Implement array/collection sorting with advanced sorting options.
			- Implement array/collection filtering options.
			- Store date-time information to assist with sorting/filtering features.
			- Implement mathematical operators for adjusting the collection size with ease. (You don't need to, it's automatically resized!)
			- Implement value search features to provide a means to easily locate and determine if a value exists within a given collection path. (Already done?).
				- This will function similarly to how file-systems work...
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VAdvance.Services.Extensions.Arrays;
using VAdvance.Services.Extensions.Objects;
using VAdvance.Services.Extensions.Strings;

namespace VAdvance.DataTypes.Enumerable
{
	public class Varray : IEnumerable
	{
		private dynamic[] ListItems={ };
		private bool _IsAssociative=false;
		private bool _Terminate;
		private bool _IsDisposed;

		public readonly Dictionary<dynamic,dynamic> DictionaryItems=new Dictionary<dynamic, dynamic>();
		public bool ForceKeyType				=false;
		public bool ForceValueType				=false;
		public bool ForcePairTypes				=false;
		public Type KeyType;
		public Type ValueType;
		public bool IsDisposed
		{
			get
			{
				return _IsDisposed;
			}
		}
		public bool Terminate
		{
			get
			{
				return _Terminate;
			}
		}

		public bool IsAssociative
		{
			get
			{
				return _IsAssociative;
			}
		}
		
		public dynamic[] Keys
		{
			get
			{
				return _IsAssociative ? DictionaryItems.Keys.ToArray() : (dynamic)ListItems.GetKeysULong();
			}
		}

		public dynamic[] Values
		{
			get
			{
				return _IsAssociative ? DictionaryItems.Values.ToArray() : ListItems;
			}
		}
		/// <summary>
		/// The number of items within the array.
		/// </summary>
		public ulong Count
		{
			get
			{
				return _IsAssociative ? (ulong)DictionaryItems.LongCount() : (ulong)ListItems.Length;
			}
		}
		/// <summary>
		/// The number of items within the array.
		/// </summary>
		public int Length
		{
			get
			{
				return (int)Count;
			}
		}
		/// <summary>
		/// Returns an array of dictionary consisting of the array contents.
		/// </summary>
		public dynamic Items
		{
			get
			{
				if(_IsAssociative)
					return DictionaryItems;
				return ListItems;
			}
		}
		/// <summary>
		/// Gets/Sets the value at a given index/location within the array.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public dynamic this[dynamic index]
		{
			get
			{
				if(IsDisposed)
					throw new InvalidOperationException(VarrayExceptionMessages.Disposed);
				if(_IsAssociative)
					return DictionaryItems.ContainsKey(index) ? DictionaryItems[index] : null;
				return ((object)index).IsNumeric() && index>-1&&index<ListItems.Length ? ListItems[index] : null;
			}
			set
			{
				if(IsDisposed)
					throw new InvalidOperationException(VarrayExceptionMessages.Disposed);
				if(((object)index).IsNumeric())
					Insert(index,value);
				else
					Add(index,value);
			}
		}
		/// <summary>
		/// Releases the resources being used by this instance of the Varray class object.
		/// </summary>
		public async void Dispose()
		{
			if(!IsDisposed)
			{
				await TerminateProcesses();
				Clear();
				_IsDisposed=true;
			}
		}
		/// <summary>
		/// Terminates the all processes currently being conducted by this instance of the Varray class object.
		/// </summary>
		public async Task<bool> TerminateProcesses()
		{
			_Terminate=true;
			await Task.Delay(100);
			_Terminate=false;
			return true;
		}
		/// <summary>
		/// Adds a new value to the array.
		/// </summary>
		/// <param name="value"></param>
		public void Add(dynamic value)
		{
			if(_IsAssociative)
			{
				Array.Resize(ref ListItems,DictionaryItems.Count);
				ulong i=0;
				foreach(KeyValuePair<dynamic,dynamic> sel in DictionaryItems)
				{
					if(Terminate)
						break;
					ListItems[i]=sel.Value;
					i++;
				}
				_IsAssociative=false;
			}
			else
			{
				Array.Resize(ref ListItems,ListItems.Length+1);
				ListItems[ListItems.Length-1]=value;
			}
		}
		/// <summary>
		/// Adds a new key-value pair to the array.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <exception cref="ArgumentException"></exception>
		public void Add(dynamic key,dynamic value)
		{
			if(_IsAssociative && (!DictionaryItems.ContainsKey(key)))
				DictionaryItems.Add(key,value);
			else if (((object)key).IsNumeric())
				Insert(key,value);
			else
			{
				_IsAssociative=true;
				DictionaryItems.Clear();
				for(ulong i = 0;i<(ulong)ListItems.Length;i++)
				{
					if(Terminate)
						break;
					DictionaryItems.Add(i, ListItems[i]);
				}
				if(!DictionaryItems.ContainsKey(key))
					DictionaryItems.Add(key,value);
				else
					throw new ArgumentException("The specified key already exists within the dictionary.");
			}
		}
		/// <summary>
		/// Inserts a given value at a specified location within the array.
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		public void Insert(dynamic index,dynamic value)
		{
			if(!_IsAssociative && ((((object)index).IsNumeric()) && index>-1))
			{
				Array.Resize(ref ListItems,index>ListItems.Length+1 ? index+1 : ListItems.Length+1);
				dynamic[] tmp=new dynamic[ListItems.Length];
				int offset=0;
				for(int i=0;i<ListItems.Length;i++)
				{
					if(Terminate)
						break;
					if(i==index)
					{
						tmp[i]=value;
						offset++;
					}
					else
						tmp[i]=ListItems[i-offset];
				}
				ListItems=tmp;
			}
		}
		/// <summary>
		/// Appends the given value to the array.
		/// </summary>
		/// <param name="value"></param>
		public void Push(dynamic value)
		{
			if(_IsAssociative)
				Add(value);
			else
			{
				if(!DictionaryItems.ContainsKey(DictionaryItems.Count))
					DictionaryItems.Add(value,value);
				else
					DictionaryItems[DictionaryItems.Last().Key.ToString()+DictionaryItems.Count.ToString()]=value;
			}
		}
		/// <summary>
		/// Adds the key-value pair to the array and converts the array if the key data-type has changed from the existing data-types.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public void Push(dynamic key,dynamic value)
		{
			Add(key,value);
		}
		/// <summary>
		/// Determines if the key exists within the array.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool ContainsKey(dynamic key)
		{
			return _IsAssociative ? DictionaryItems.ContainsKey(key) : Contains(key);
		}
		/// <summary>
		/// Determines if the value exists within the array.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Contains(dynamic value)
		{
			return _IsAssociative ? (DictionaryItems.ContainsKey(value) || DictionaryItems.ContainsValue(value)) : ContainsValue(value);
		}
		/// <summary>
		/// Determines if the value exists within the array.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool ContainsValue(dynamic value)
		{
			if(_IsAssociative)
				return DictionaryItems.ContainsValue(value);
			else
				for(int i = 0;i<ListItems.Length;i++)
				{
					if(Terminate)
						break;
					if(ListItems[i]==value)
						return true;
				}
			return false;
		}
		/// <summary>
		/// Gets the index or key from a given value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>the <see cref="long">index</see> of a non-associative array, or the key of the given value.</returns>
		public dynamic IndexOf(dynamic value)
		{
			if(_IsAssociative)
				foreach(KeyValuePair<dynamic, dynamic> sel in DictionaryItems)
				{
					if(Terminate)
						break;
					if(sel.Value==value)
						return sel;
				}
			else
				for(long i = 0;i<ListItems.Length;i++)
				{
					if(Terminate)
						return -1;
					if(ListItems[i]==value)
						return i;
				}
			return -1;
		}
		/// <summary>
		/// Removes the given key if it was found within the Varray items.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool RemoveKey(dynamic key)
		{
			return _IsAssociative && DictionaryItems.Remove(key);
		}
		/// <summary>
		/// Removes a given key or value that is located within the Varray items.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Remove(dynamic value)
		{
			if(_IsAssociative)
				return DictionaryItems.ContainsValue(value) ? DictionaryItems.Remove(IndexOf(value)) : RemoveKey(value);
			else if(Contains(value))
			{
				dynamic[] tmp={ };
				foreach(dynamic sel in ListItems)
				{
					if(Terminate)
						break;
					if(sel!=value)
					{
						Array.Resize(ref tmp, tmp.Length+1);
						tmp[tmp.Length-1]=sel;
					}
				}
				return true;
			}
			return false;
		}
		/// <summary>
		/// Purges the contents of the array.
		/// </summary>
		public void Clear()
		{
			Array.Clear(ListItems,0,ListItems.Length);
			DictionaryItems.Clear();
		}
		/// <summary>
		/// Generates a JSON string equivalent of this array object.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string res="";
			if(_IsAssociative)
			{
				foreach(KeyValuePair<dynamic,dynamic> sel in DictionaryItems)
				{
					if(Terminate)
						break;
					res +=(res.Length > 0 ? "," : "") + GetValueString(sel.Key) + ":" + GetValueString(sel.Value);
				}
				return "{"+res+"}";
			}
			for(ulong i = 0;i<Count;i++)
			{
				if(Terminate)
					break;
				res+=(i>0 ? "," : "") + GetValueString(Items[i]);
			}
			return "["+res+"]";
		}
		/// <summary>
		/// Generates a formatted JSON string.
		/// </summary>
		/// <returns></returns>
		public string ToFormattedString()
		{
			string res="";
			int depth=0;
			if(_IsAssociative)
			{
				foreach(KeyValuePair<dynamic, dynamic> sel in DictionaryItems)
				{
					if(Terminate)
						break;
					res+="\n"+("\t".Repeat(depth))+(res.Length>0 ? "," : "") + GetFormattedValue(sel.Key) + ":" + GetFormattedValue(sel.Value);
				}
				return "{"+res+"\n}";
			}
			for(ulong i = 0;i<Count;i++)
			{
				if(Terminate)
					break;
				res+="\n"+("\t".Repeat(depth)) + GetFormattedValue(Items[i]) + (i<Count-1 ? "," : "");
			}
			return "["+res+"\n]";
		}
		/// <summary>
		/// Creates a string representation of the value.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="depth"></param>
		/// <returns></returns>
		private static string GetFormattedValue(dynamic value=null, int depth=0)
		{
			if(value!=null)
			{
				Type t=((object)value).GetType();
				string res="";
				if(t.IsArray || (t.Name.Contains("List") || (value is Varray) && !value.IsAssociative))
				{
					foreach(dynamic sel in value)
						res+="\n"+("\t".Repeat(depth+1))+(res.Length>0 ? "," : "")+GetFormattedValue(sel,depth+1);
					res="["+res+"\n"+("\t".Repeat(depth-1))+"]";
				}
				else if(t.IsEnum || t.Name.Contains("Dictionary") || ((value is Varray) && value.IsAssociative))
				{
					foreach(KeyValuePair<dynamic,dynamic> sel in value)
						res+="\n"+("\t".Repeat(depth+1))+(res.Length>0 ? "," : "") + GetValueString(sel.Key) + ":" + GetFormattedValue(sel.Value,depth+1);
					res="{"+res+"\n"+("\t".Repeat(depth-1))+"}";
				}
				else
					res=GetValueString(value);
				return res;
			}
			return "null";
		}
		/// <summary>
		/// Creates a string representation of the value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static string GetValueString(dynamic value)
		{
			return value!=null ? (value is string ? "\""+value+"\"" : value.ToString()) : "null";
		}

		[Serializable]
		private sealed class ArrayEnumerator:IEnumerator, ICloneable
		{
			private Array array;

			private int index;

			private int endIndex;

			private int startIndex;

			private int[] _indices;

			private bool _complete;

			public dynamic Current
			{
				get
				{
					if(index < startIndex)
						throw new InvalidOperationException("InvalidOperation_EnumNotStarted");
					if(_complete)
						throw new InvalidOperationException("InvalidOperation_EnumEnded");
					return array.GetValue(_indices);
				}
			}

			internal ArrayEnumerator(Array array,int index,int count)
			{
				this.array = array;
				this.index = index - 1;
				startIndex = index;
				endIndex = index + count;
				_indices = new int[array.Rank];
				int num = 1;
				for(int i = 0;i < array.Rank;i++)
				{
					_indices[i] = array.GetLowerBound(i);
					num *= array.GetLength(i);
				}
				_indices[_indices.Length - 1]--;
				_complete = num == 0;
			}

			private void IncArray()
			{
				int rank = array.Rank;
				_indices[rank - 1]++;
				for(int num = rank - 1;num >= 0;num--)
					if(_indices[num] > array.GetUpperBound(num))
					{
						if(num == 0)
						{
							_complete = true;
							break;
						}
						for(int i = num;i < rank;i++)
							_indices[i] = array.GetLowerBound(i);
						_indices[num - 1]++;
					}
			}

			public object Clone()
			{
				return MemberwiseClone();
			}

			public Varray ExactClone()
			{
				return (Varray)MemberwiseClone();
			}

			public bool MoveNext()
			{
				if(_complete)
				{
					index = endIndex;
					return false;
				}
				index++;
				IncArray();
				return !_complete;
			}

			public void Reset()
			{
				index = startIndex - 1;
				int num = 1;
				for(int i = 0;i < array.Rank;i++)
				{
					_indices[i] = array.GetLowerBound(i);
					num *= array.GetLength(i);
				}
				_complete = num == 0;
				_indices[_indices.Length - 1]--;
			}
		}

		public IEnumerator GetEnumerator()
		{
			return _IsAssociative ? (IEnumerator)DictionaryItems.GetEnumerator() : new ArrayEnumerator(Values, 0, Length);
		}



	}
}
