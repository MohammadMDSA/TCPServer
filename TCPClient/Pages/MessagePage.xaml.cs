using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Networking.Sockets;
using Windows.Networking;
using TCPServer;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TCPClient.Pages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MessagePage : Page
	{
		public MessagePage()
		{
			this.InitializeComponent();
		}

		private async void SendButton_Click(object sender, RoutedEventArgs e)
		{
			if (InputBox.Text == string.Empty)
				return;
			StreamSocket socket = new StreamSocket();
			try
			{
				HostName serverHost = new HostName(Setting.ServerName);

				string serverPort = Setting.PortNumber;
				await socket.ConnectAsync(serverHost, serverPort);

				Stream stramOut = socket.OutputStream.AsStreamForWrite();
				StreamWriter writer = new StreamWriter(stramOut);
				string request = InputBox.Text;
				await writer.WriteLineAsync(request);
				await writer.FlushAsync();
			
				Stream streamIn = socket.InputStream.AsStreamForRead();
				StreamReader reader = new StreamReader(streamIn);
				string response = await reader.ReadLineAsync();

				RecievedBox.Text += response + "\n\n";
			}
			catch (Exception ex)
			{
				MainPage.RootPage.NotifyUser("Failed to recieve message", NotifyType.ErrorMessage);
				MainPage.RootPage.NotifyUser(ex.Message, NotifyType.ErrorMessage);
				return;
			}

		}
	}
}
