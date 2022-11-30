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

namespace VAdvance
{
	public partial class Form1:Form
	{

		private readonly Network NetIns;

		public Form1()
		{
			InitializeComponent();
			CenterToScreen();


			Executing();




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


		public void DevOperation()
		{

		}

		public void Write(dynamic q)
		{
			if(q!=null)
			{
				if(q is List<string>)
				{
					foreach(string s in q)
						DevTextboxControl.Text+="\r\n"+s;
				}
				else
				{
					string value=q.ToString();
					if(value.CheckValue())
						DevTextboxControl.Text=Regex.Replace(value,"[\n]","\r\n");
				}
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
