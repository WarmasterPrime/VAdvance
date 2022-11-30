using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using VAdvance.Services.Extensions.Objects;
using VAdvance.Services.Extensions.Strings;

namespace VAdvance.Services.Networking
{
	public class Network
	{
		public string Url;
		public int Port=22;
		public string Ip;
		public Form1 WindowIns;
		public Dictionary<string,string> Items=new Dictionary<string, string>();
		public string[] Headers={
			"Content-Type","application/x-www-form-urlencoded"
		};

		public Network()
		{
			Ip=GetDefaultGateway().ToString();
		}

		public async Task<Dictionary<string,string>> GetSwitch(string value = "GET /\n")
		{
			string ip=Ip;
			Dictionary<string,string> res=new Dictionary<string, string>();
			TcpClient client=new TcpClient(ip,Port);
			NetworkStream ns=client.GetStream();
			byte[] bts=Encoding.ASCII.GetBytes(value);
			ns.Write(bts,0,bts.Length);

			//byte[] buffer=new byte[100];
			int bytes=0;
			List<string>data=new List<string>();
			//bytes=ns.Read(buffer,0,buffer.Length);
			do
			{
				if(ns.CanRead)
				{
					byte[] buffer=new byte[4096];
					bytes=await ns.ReadAsync(buffer,0,4096);
					string v=Encoding.ASCII.GetString(buffer,0,bytes);
					WindowIns.Append(v);
					if(bytes<buffer.Length)
						break;
				}
			}
			while(bytes>0);
			return res;
		}

		public string GetIp()
		{
			return GetLocalIpAddresses()[0].ToString();
		}

		public IPAddress[] GetLocalIpAddresses()
		{
			return Dns.GetHostAddresses(Dns.GetHostName());
		}

		public IPAddress GetLocalIpv4Address()
		{
			IPAddress[] l=GetLocalIpAddresses();
			foreach(IPAddress sel in l)
				if(sel.AddressFamily==AddressFamily.InterNetwork)
					return sel;
			return l[l.Length-1];
		}

		public IPAddress GetDefaultGateway()
		{
			return NetworkInterface.GetAllNetworkInterfaces().Where(n => n.OperationalStatus==OperationalStatus.Up).Where(n => n.NetworkInterfaceType!=NetworkInterfaceType.Loopback).SelectMany(n => n.GetIPProperties()?.GatewayAddresses).Select(g => g?.Address).Where(b => b.AddressFamily==AddressFamily.InterNetwork).Where(a => a!=null).FirstOrDefault();
		}

		public async Task<dynamic> Send()
		{
			return (await Ping(Url))==IPStatus.Success && Items.CheckValue() ? await (await new HttpClient().PostAsync(Url,new FormUrlEncodedContent(Items))).Content.ReadAsStringAsync() : null;
		}

		public static async Task<string> WGet(string destination)
		{
			return await new WebClient().DownloadStringTaskAsync(destination);
		}

		public static void DownloadFile(string destination,string save_to_dir)
		{
			if(save_to_dir.IsDir())
			{
				Uri url=new Uri(destination);
				new WebClient().DownloadFileAsync(url,(save_to_dir.Substring(save_to_dir.Length-1,1)!="/" ? save_to_dir+"/" : save_to_dir) + Uri.UnescapeDataString(url.Segments[url.Segments.Length-1]));
			}
		}

		public static void UploadFile(string destination,string file_path)
		{
			if(file_path.IsFile())
			{
				Uri url=new Uri(destination);
				new WebClient().UploadFileAsync(url,file_path);
			}
		}

		public static async Task<bool> IsReachable(string destination)
		{
			return (await Ping(destination))==IPStatus.Success;
		}

		public static async Task<IPStatus> Ping(string destination,int timeout = 50)
		{
			return (await new Ping().SendPingAsync(destination,timeout)).Status;
		}


	}
}
