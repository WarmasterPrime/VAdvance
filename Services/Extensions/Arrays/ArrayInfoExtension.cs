namespace VAdvance.Services.Extensions.Arrays
{
	public static class ArrayInfoExtension
	{

		public static int[] GetKeys(this dynamic[] arr)
		{
			int[] res=new int[arr.Length];
			for(int i=0;i<arr.Length;i++)
				res[i]=i;
			return res;
		}

		public static ulong[] GetKeysULong(this dynamic[] arr)
		{
			ulong[] res=new ulong[arr.Length];
			for(ulong i=0;i<(ulong)arr.Length;i++)
				res[i]=i;
			return res;
		}

	}
}
