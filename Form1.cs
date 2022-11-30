using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VAdvance.Services.Extensions.Strings;
using VAdvance.Services.Extensions.Arrays;
using VAdvance.DataTypes.Arrays;
using VAdvance.DataTypes.Enumerable;
using VAdvance.Services.Networking;
using System.Net;
using VAdvance.Services.Experimental.Assembly;
using VAdvance.Services.Processing.Software;
using System.Diagnostics;

namespace VAdvance
{
	public partial class Form1:Form
	{

		private readonly Network NetIns;

		public Form1()
		{
			InitializeComponent();
			CenterToScreen();


			//Executing();
			Executor();

			
			//Write(p.IsExecutable());




			//NetIns=new Network
			//{
			//	WindowIns=this
			//};

			//DevOperation();

			//NetIns.Ip=NetIns.GetDefaultGateway().ToString();
			//NetIns.WindowIns=this;
			//NetIns.GetSwitch();


			/*
			Varray l=new Varray
			{
				{0,"Apples" },
				{1,"Oranges" },
				{2,"Peaches" },
				{10,new string[]{"origins","popcorn" } },
				{11,new Dictionary<string,string>{{"Hello","World" } } },
				{12,new List<string>{"Awesomeness","Hawaii" } },
				{ "Foo","Bar" }
			};
			Write(l.ToFormattedString());
			*/
			//Write(l.ToString());

			//l.Push("Item","Value");
			//l.Push(0,'\t');
			//l.Push('a',3.14);

		}

		public async void Executor()
		{
			string p="C:\\Users\\sitesupport\\Desktop\\test.bat";
			string[] l={
				"C:\\Users\\sitesupport\\Desktop\\test.bat",
				"C:\\Users\\sitesupport\\Desktop\\test.bat",
				"C:\\Users\\sitesupport\\Desktop\\test.bat"
			};
			VProcess ins=new VProcess
			{
				Path=p
			};
			//ins.RedirectOutput+=RedirectedOutput;
			//ins.RedirectRawOutput+=Ins_RedirectRawOutput;
			Write(await ins.Execute());
		}

		private void Ins_RedirectRawOutput(object sender,string output)
		{
			Write(output,true);
		}

		public async void RedirectedOutput(object sender,DataReceivedEventArgs e)
		{
			await Task.Delay(100);
			Write(e.Data,true);
		}

		public async void Executing()
		{
			string ip="172.20.";
			List<string>l=new List<string>();
			int o=40;
			while(o<100)
			{
				string tip=ip+o+".";
				int i=40;
				while(i<100)
				{
					if(await Network.Ping(tip+i.ToString(),50)==System.Net.NetworkInformation.IPStatus.Success)
						DevTextboxControl.Text+="\r\n"+tip+i.ToString();
					i++;
				}
				DevTextboxControl.Text+="-";
				o++;
			}
			DevTextboxControl.Text+="\r\nCOMPLETED\r\n";
		}


		public void Write(dynamic q, bool append=false)
		{
			if(q!=null)
			{
				string res=string.Empty;
				if(q is List<string> || q is string[])
					foreach(string s in q)
						res+="\r\n"+s;
				else if(q is Varray varray)
					res=varray.ToFormattedString().Replace("\n","\r\n");
				else if(q is bool)
					res=q ? "TRUE" : "FALSE";
				else
				{
					string value=q.ToString();
					if(value.CheckValue())
						res=Regex.Replace(value,"[\n]","\r\n");
				}
				if(append)
					DevTextboxControl.Text+=res;
				else
					DevTextboxControl.Text=res;
			}
		}

		public void Append(dynamic q)
		{
			if(q!=null)
			{
				string value=q.ToString();
				if(value.CheckValue())
					DevTextboxControl.Text+="\r\n"+Regex.Replace(value,"[\n]","\r\n");
			}
		}

		private void RunNetworkCommandButtonControl_OnClick(object sender,EventArgs e)
		{
			ExecuteNetworkCommand();
		}

		public async void ExecuteNetworkCommand()
		{
			string value=Regex.Replace(NetworkTextInputControl.Text,"[\\r]","");
			DevTextboxControl.Text="";
			await NetIns.GetSwitch(value);
		}

	}
}
