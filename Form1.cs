using System.Text.RegularExpressions;
using System.Windows.Forms;
using VAdvance.DataTypes.Arrays;
using VAdvance.Services.Extensions.Arrays;
using VAdvance.Services.Extensions.Strings;

namespace VAdvance
{
	public partial class Form1:Form
	{
		public Form1()
		{
			InitializeComponent();
			//Write("apple-sause is always Awesome to particularly (but not acceptably) have!".Capitalize(StringModificationFlags.ByWhitespace));
			//Write("apple-sause is always Awesome to particularly (but not acceptably) have! hello world!\n how are you today?\ni hope you're day is going well; happy!".Capitalize(StringModificationFlags.BySentence));

<<<<<<< HEAD
			array l = new array
			{
				{ "Apples","Oranges" },
				{ 0,"Peaches" }
=======
			//string v0="Ripples";
			//string v0="Apples";
			//string v0="Pineapples";
			string v0="Orion";
			//string v0="Rain";
			string v1="apple";
			Write(v0.Soundex());
			//Write(v0.Levenshtein(v1));



			string[] a={
				"apples","oranges"
>>>>>>> master
			};
			Write(l.ToString());

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



	}
}
