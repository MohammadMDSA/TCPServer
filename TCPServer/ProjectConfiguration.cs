using System.Collections.Generic;
using TCPServer.Pages;

namespace TCPServer
{
	partial class MainPage
	{
		public const string APP_TITLE = "TCP Server";

		private List<Scenario> Scenarios = new List<Scenario>()
		{
			new Scenario() {PageType = typeof(ServerLog), Icon="\uE81E", Title="Server Log"},
			new Scenario() {PageType = typeof(CreateServer), Icon = "\uEC7A", Title = "Create Server"}
		};
	}
}
