using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPServer.Pages;
using Windows.UI.Xaml.Controls;

namespace TCPServer
{
	partial class MainPage
	{
		public const string APP_TITLE = "TCP Server";

		private List<Scenario> Scenarios = new List<Scenario>()
		{
			new Scenario() {PageType = typeof(CreateServer), Icon = "\uEC7A", Title = "Create Server"}
		};
	}

	class Scenario
	{
		public Type PageType { get; set; }
		public string Title { get; set; }
		public string Icon { get; set; }
	}
}
