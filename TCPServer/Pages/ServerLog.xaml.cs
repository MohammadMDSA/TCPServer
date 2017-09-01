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
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TCPServer.Pages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class ServerLog : Page
	{
		public static ServerLog ServerLogClass;
		private static List<Log> LogsList = new List<Log>();

		public ServerLog()
		{
			this.InitializeComponent();

			ServerLogClass = this;
		}

		public void AddLog(string log, LogType type)
		{
			LogsList.Add(new Log(type, log));
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			foreach (var item in LogsList)
			{
				Run run = new Run();
				run.Text = item.Message;
				Paragraph par = new Paragraph();
				par.Inlines.Add(run);
				par.Foreground = new SolidColorBrush(item.MessageColor);
				LogBlock.Blocks.Add(par);
			}
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			LogsList.Clear();
			LogBlock.Blocks.Clear();
		}
	}

	public enum LogType
	{
		Error,
		Status
	}

	public class Log
	{
		public LogType Type { get; }
		public string Message { get; }
		public Color MessageColor { get; }

		public Log(LogType type, string message)
		{
			Type = type;
			Message = message;
			MessageColor = type == LogType.Error ? Colors.Red : Colors.Green;
		}
	}
}
