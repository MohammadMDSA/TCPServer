using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TCPServer.Pages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CreateServer : Page
	{
		public CreateServer()
		{
			this.InitializeComponent();
		}

		private void PortBox_GotFocus(object sender, RoutedEventArgs e)
		{
			PortLabel.Foreground = new SolidColorBrush(Colors.Red);
		}

		private void PortBox_LostFocus(object sender, RoutedEventArgs e)
		{
			PortLabel.Foreground = new SolidColorBrush(Colors.Black);
		}
	}
}
