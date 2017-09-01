using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPClient;
using TCPClient.Pages;
using TCPServer;

namespace TCPServer
{
	public partial class MainPage
	{
		public const string APP_TITLE = "TCP Client";

		private List<Scenario> Scenarios = new List<Scenario>()
		{
			new Scenario() {PageType = typeof(MessagePage), Icon="\uE119", Title="Message"},
			new Scenario() {PageType = typeof(Setting), Icon="\uE115", Title="Setting"}
		};
	}
}
