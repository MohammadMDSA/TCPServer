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

namespace TCPClient.Pages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Setting : Page
	{
		public Setting()
		{
			this.InitializeComponent();
		}

		private void ConnectButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void HostNameText_GotFocus(object sender, RoutedEventArgs e)
		{
			HostNameLable.Foreground = new SolidColorBrush(Colors.Red);
		}

		private void HostNameText_LostFocus(object sender, RoutedEventArgs e)
		{
			HostNameLable.Foreground = new SolidColorBrush(Colors.Black);
		}

		private void PortNumberBox_LostFocus(object sender, RoutedEventArgs e)
		{
			PortNumberLable.Foreground = new SolidColorBrush(Colors.Black);
		}

		private void PortNumberBox_GotFocus(object sender, RoutedEventArgs e)
		{
			PortNumberLable.Foreground = new SolidColorBrush(Colors.Red);

		}
	}
}
