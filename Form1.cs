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

			array l = new array
			{
				{ "Apples","Oranges" },
				{ 0,"Peaches" }
			};
			Write(l.ToString());

		}

		public void Write(string value)
		{
			if(value.CheckValue())
				DevTextboxControl.Text=Regex.Replace(value,"[\n]","\r\n");
		}


	}
}
