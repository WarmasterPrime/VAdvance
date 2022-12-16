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
using VAdvance.Services.Extensions.Numerics;
using System.Media;
using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;
using VAdvance.Services.Ai.ImageDetection;
using VAdvance.Services.Utilities.Applications.SystemManagement;
using System.Runtime.Remoting.Lifetime;
using VAdvance.Services.FileSystem;
using VAdvance.Services.TextProcessing.Cryptography;

namespace VAdvance
{
	public partial class Form1:Form
	{

		private readonly Network NetIns;

		private readonly Videct DevIns=new Videct();

		private Image LastImage;

		public Form1()
		{
			InitializeComponent();
			CenterToScreen();


			//openFileDialogControl.Multiselect=false;
			//openFileDialogControl.RestoreDirectory=true;
			//openFileDialogControl.Title="Select an image...";
			//openFileDialogControl.Filter="Image Files(*.png;*.jpeg;*.jpg;*.webp;*.gif)|*.png;*.jpeg;*.jpg;*.webp;*.gif|All files (*.*)|*.*";

			//LastImage=ImageControl.Image;


			//DevFunc();

			//DevFuncOne();
			Vcoder ins=new Vcoder();
			string v="Hello World";
			string res=ins.Encode(v);
			Write(res);

			

			//Executing();
			//Executor();

			//string v="";
			//Write(v.GetNumberFromRoman());

			//this.FormClosed+=Form1_FormClosed;
			
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

			dynamic[] list={
				"Hello",
				"World"
			};

			foreach(var sel in l)
			{
				var dev=sel;
				var dev_type=dev.GetType();
				var d=dev_type;
			}

			object test=l.GetEnumerator().Current;

			var res=test is Varray;

			Write(res);
			*/
			//Write(l.ToFormattedString());
			
			//Write(l.ToString());

			//l.Push("Item","Value");
			//l.Push(0,'\t');
			//l.Push('a',3.14);

		}

		public async void DevFuncOne()
		{
			DevTextboxControl.TextChanged+=DevTextboxControl_TextChanged;
			string path="D:\\";
			//string[] l=Directory.GetDirectories(path,"*.*",SearchOption.AllDirectories);
			await Task.Delay(100);
			var dtc=DateTime.Now;
			List<string> l=await Vystem.AsyncScan(path);
			labelControl_DebugLabel.Text=l.Count.ToString()+" Time: "+(new DateTime(DateTime.Now.Ticks-dtc.Ticks)).ToString("HH:mm:ss");;
			await Task.Delay(100);
			//Write(l);
			string look="D:\\SteamLibrary\\steamapps\\common\\Streets of Rage 4\\data\\62470333.wem";
			await Task.Delay(100);
			Write(l.Contains(look));
			labelControl_DebugLabel.Text=l.Count.ToString()+" | COMPLETED | Time: "+(new DateTime(DateTime.Now.Ticks-dtc.Ticks)).ToString("HH:mm:ss");
			//string data="";
			/*
			ulong i=0;
			foreach(string s in l)
			{
				data+="\r\n"+s;
				i++;
				if(i%(ulong)(l.Count/100)==0)
				{
					DevTextboxControl.Text+=data;
					data="";
					await Task.Delay(1);
				}
			}
			*/
			
			//await Task.Delay(100);
			//DevTextboxControl.Text=data;
			/*
			DevTextboxControl.TextChanged+=DevTextboxControl_TextChanged;
			await Task.Delay(100);
			var dtc=DateTime.Now;
			ulong i=0;
			string data="";
			foreach(string dir in l)
			{
				//await AsyncWrite(DevTextboxControl,"\n"+dir,true);
				//Write("\n"+dir,true);
				data+="\r\n"+dir;
				i++;
				//DateTime dt=new DateTime(DateTime.Now.Ticks-dtc.Ticks);
				//labelControl_DebugLabel.Text=i.ToString()+" Time: "+(new DateTime(DateTime.Now.Ticks-dtc.Ticks)).ToString("HH:mm:ss");
				if(i%10000==0)
				{
					labelControl_DebugLabel.Text=i.ToString()+" / "+l.Length+" | Time: "+(new DateTime(DateTime.Now.Ticks-dtc.Ticks)).ToString("HH:mm:ss");
					DevTextboxControl.Text+=data;
					data="";
					await Task.Delay(1);
				}
			}
			labelControl_DebugLabel.Text=i.ToString()+" Time: "+(new DateTime(DateTime.Now.Ticks-dtc.Ticks)).ToString("HH:mm:ss");
			//Write(data);
			//labelControl_DebugLabel.Text+=" Time: "+(DateTime.Now-dtc).ToString("H:mm:ss");
			*/
		}

		private void DevTextboxControl_TextChanged(object sender,EventArgs e)
		{
			TextBox elm=(TextBox)sender;
			elm.SelectionStart=elm.TextLength;
			elm.ScrollToCaret();
		}

		public async void DevFunc()
		{
			ImageUploadBtnControl.Enabled=false;
			ScanImageBtnControl.Enabled=false;
			await Task.Delay(1);
			DevIns.SectorSize=(int)SectorSizeInputControl.Value;
			DevIns.Threshold=(int)ColorThresholdInputControl.Value;
			ImageControl.Image=LastImage;
			DevIns.ImageControl=ImageControl;
			DevIns.ProcessImage();

			ImageUploadBtnControl.Enabled=true;
			ScanImageBtnControl.Enabled=true;

		}

		private void Form1_FormClosed(object sender,FormClosedEventArgs e)
		{
			
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

		public async Task<bool> AsyncWrite(TextBox elm,dynamic q,bool append = false)
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
					elm.Text+=res;
				else
					elm.Text=res;
			}
			else
				elm.Text="[NULL]";
			await Task.Delay(1);
			return true;
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
			else
			{
				DevTextboxControl.Text="[NULL]";
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

		private void ImageUploadBtnControl_Click(object sender=null,EventArgs e=null)
		{
			if(openFileDialogControl.ShowDialog() == DialogResult.OK)
			{
				Operation();
				openFileDialogControl.InitializeLifetimeService();
				openFileDialogControl.Dispose();
			}
		}

		private async Task<bool> Operate()
		{
			ImageUploadBtnControl.Enabled=false;
			ScanImageBtnControl.Enabled=false;

			DevIns.SectorSize=(int)SectorSizeInputControl.Value;
			DevIns.Threshold=(int)ColorThresholdInputControl.Value;
			
			ImageControl.Image.Dispose();
			Image img=Image.FromFile(openFileDialogControl.FileName);
			ImageControl.Image=img;
			await Task.Delay(1);
			if(AdvOutChkControl.Checked)
				DevIns.ProcessImage();
			else
				DevIns.ImageControl=ImageControl;
			DevIns.OutlineImage();
			LastImage=ImageControl.Image;

			img.Dispose();
			img=null;
			//openFileDialogControl.Reset();

			
			ImageUploadBtnControl.Enabled=true;
			ScanImageBtnControl.Enabled=true;
			//ImageControl.Dispose();
			return true;
		}

		private async void Operation()
		{
			await Task.Delay(100);
			await Operate();
		}

		private void ScanImageBtnControl_Click(object sender,EventArgs e)
		{
			Operation();
		}
	}
}
