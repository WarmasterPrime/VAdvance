using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VAdvance.Services.Systems.Microsoft.Windows
{
	public class WindowsOs
	{
		private static Rectangle BoundRect;
		private static Rectangle OldRect=Rectangle.Empty;
		private static Point LastPosition;
		private static bool CursorMovementEnabled=true;

		public static void EnableMouse()
		{
			if(!CursorMovementEnabled)
			{
				Cursor.Clip=OldRect;
				Cursor.Show();
				Cursor.Position=LastPosition;
				CursorMovementEnabled=true;
			}
		}

		public static void DisableMouse()
		{
			if(CursorMovementEnabled)
			{
				OldRect=Cursor.Clip;
				BoundRect=new Rectangle(Screen.PrimaryScreen.Bounds.Width/2, Screen.PrimaryScreen.Bounds.Height/2, 1, 1);
				Cursor.Clip=BoundRect;
				Cursor.Hide();
				LastPosition=Cursor.Position;
				CursorMovementEnabled=false;
			}
		}

		public bool PreFilterMessage(ref Message m)
		{
			return m.Msg>=0x201&&m.Msg<=0x206;
		}

	}
}
