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

namespace VAdvance
{
	public partial class Form1:Form
	{

		private Network NetIns;

		public Form1()
		{
			InitializeComponent();


			NetIns=new Network
			{
				WindowIns=this
			};

			DevOperation();

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

		public void DevOperation()
		{
			string file_name="Restricted and abandoned project.pdf";
			Network.DownloadFile("http://doft.ddns.net/"+file_name,"C:\\Users\\Sitesupport\\Desktop\\Daniel\\Developmental\\");
		}



		public void Write(dynamic q)
		{
			if(q!=null)
			{
				string value=q.ToString();
				if(value.CheckValue())
					DevTextboxControl.Text=Regex.Replace(value,"[\n]","\r\n");
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
