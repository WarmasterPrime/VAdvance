using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Forms;
using System.Windows.Input;

namespace VAdvance.Services.Systems.Microsoft.Windows.Peripherals.Input
{
	public class MouseCursor
	{

		private Rectangle BoundRect;
		private Rectangle OldRect=Rectangle.Empty;
		private System.Drawing.Point LastPosition;

		private bool _Locked;

		public bool Locked
		{
			get
			{
				return _Locked;
			}
			set
			{
				if(_Locked!=value)
				{
					_Locked=value;
					if(!value)
					{
						OldRect=System.Windows.Forms.Cursor.Clip;
						BoundRect=new Rectangle(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width/2, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height/2, 1, 1);
						System.Windows.Forms.Cursor.Clip=BoundRect;
						System.Windows.Forms.Cursor.Hide();
						LastPosition=System.Windows.Forms.Cursor.Position;
					}
					else
					{
						System.Windows.Forms.Cursor.Clip=OldRect;
						System.Windows.Forms.Cursor.Show();
						System.Windows.Forms.Cursor.Position=LastPosition;
					}
				}
			}
		}

		public static readonly RoutedEvent MouseDown			=EventManager.RegisterRoutedEvent("MouseDown", RoutingStrategy.Bubble, typeof(MouseButtonEventHandler), typeof(Mouse));
		public static readonly RoutedEvent MouseUp				=EventManager.RegisterRoutedEvent("MouseUp", RoutingStrategy.Bubble, typeof(MouseButtonEventHandler), typeof(Mouse));
		public static readonly RoutedEvent MouseWheelEvent		=EventManager.RegisterRoutedEvent("MouseWheel", RoutingStrategy.Bubble, typeof(MouseWheelEventHandler), typeof(Mouse));
		public static readonly RoutedEvent MouseEnterEvent		=EventManager.RegisterRoutedEvent("MouseEnter", RoutingStrategy.Direct, typeof(MouseEventHandler), typeof(Mouse));
		public static readonly RoutedEvent MouseLeaveEvent		=EventManager.RegisterRoutedEvent("MouseLeave", RoutingStrategy.Direct, typeof(MouseEventHandler), typeof(Mouse));
		public static readonly RoutedEvent MouseMoveEvent		=EventManager.RegisterRoutedEvent("MouseMove", RoutingStrategy.Bubble, typeof(MouseEventHandler), typeof(Mouse));
		public static IInputElement DirectlyOver				=Mouse.DirectlyOver;
		public MouseCursor(){}


	}
}
