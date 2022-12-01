using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace VAdvance.Services.System.Readers.Audio
{
	public class Visualizer : DialogDebuggerVisualizer
	{

		protected override void Show(IDialogVisualizerService win_service,IVisualizerObjectProvider obj)
		{
			MessageBox.Show(obj.GetObject().ToString());
		}

		public AxWindowsMediaPlayer PlayerControl;

		private void Dev()
		{
			
		}


	}
}
