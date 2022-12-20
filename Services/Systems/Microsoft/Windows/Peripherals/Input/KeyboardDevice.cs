using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VAdvance.Services.Systems.EventHandlers;

namespace VAdvance.Services.Systems.Microsoft.Windows.Peripherals.Input
{
	public class KeyboardDevice
	{

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

				}
			}
		}

		public static readonly RoutedEvent GotKeyboardFocus				=EventManager.RegisterRoutedEvent("GotKeyboardFocus", RoutingStrategy.Bubble, typeof(KeyboardFocusChangedEventHandler), typeof(Keyboard));
		public event KeyboardKeyDownEvent KeyDown;

	}
}
