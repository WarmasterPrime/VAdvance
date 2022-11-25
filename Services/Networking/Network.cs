using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using VAdvance.Services.Extensions.Objects;

namespace VAdvance.Services.Networking
{
	public class Network
	{

		public string Url;
		public int Port=80;
		public Dictionary<string,string> Items=new Dictionary<string, string>();
		public string[] Headers={
			"Content-Type","application/x-www-form-urlencoded"
		};

		public Network() { }

		public async Task<dynamic> Send()
		{
			return (await Ping(Url))==IPStatus.Success && Items.CheckValue() ? await (await new HttpClient().PostAsync(Url,new FormUrlEncodedContent(Items))).Content.ReadAsStringAsync() : null;
		}

		public static async Task<IPStatus> Ping(string destination, int timeout=500)
		{
			return destination.CheckValue() ? (await new Ping().SendPingAsync(destination,timeout)).Status : IPStatus.BadDestination;
		}

	}
}
