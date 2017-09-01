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
using Windows.Networking.Sockets;

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

		private async void SubmitButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				StreamSocketListener socketlistener = new StreamSocketListener();

				socketlistener.ConnectionReceived += SocketListener_ConnectionReceived;

				await socketlistener.BindServiceNameAsync(PortBox.Text);

				ServerLog.ServerLogClass.AddLog("Server started successfully on port " + PortBox.Text + ".", LogType.Status);
			}
			catch (Exception ex)
			{
				MainPage.RootPage.NotifyUser(ex.Message, NotifyType.ErrorMessage);
				ServerLog.ServerLogClass.AddLog("Faild to start server on port " + PortBox.Text + ".", LogType.Error);
			}
		}

		private async void SocketListener_ConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
		{
			var clientName = args.Socket.Information.LocalAddress.DisplayName;
			MainPage.RootPage.NotifyUser("Recieved a connection from " + clientName + ".", NotifyType.StatusMessage);
			Stream inStream = args.Socket.InputStream.AsStreamForRead();
			StreamReader reader = new StreamReader(inStream);
			string request = await reader.ReadLineAsync();

			Stream outStream = args.Socket.OutputStream.AsStreamForWrite();
			StreamWriter writer = new StreamWriter(outStream);
			await writer.WriteLineAsync(request);
			await writer.FlushAsync();
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			PortBox.Text = string.Empty;
		}
	}
}
