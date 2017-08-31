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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TCPServer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		static MainPage RootPage;

        public MainPage()
        {
            this.InitializeComponent();
			RootPage = this;
        }

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			AppTitle.Text = APP_TITLE;
			ScenarioListBox.ItemsSource = Scenarios;
			ScenarioListBox.SelectedIndex = 0;
			Windows.UI.ViewManagement.StatusBar.GetForCurrentView().ShowAsync();
		}

		private void ToggleButton_Click(object sender, RoutedEventArgs e)
		{
			SidePanel.IsPaneOpen = !SidePanel.IsPaneOpen;
		}

		private void SidePanel_PaneClosing(SplitView sender, SplitViewPaneClosingEventArgs args)
		{
			SidePanelTggle.IsChecked = false;
		}

		public Frame GetRootFrame()
		{
			return this.MainFrame;
		}

		public void NotifyUser(string message, NotifyType type)
		{
			if (Dispatcher.HasThreadAccess)
			{
				UpdateStatus(message, type);
			}
			else
			{
				var task = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => UpdateStatus(message, type));
			}
		}

		private void UpdateStatus(string message, NotifyType type)
		{
			switch (type)
			{
				case NotifyType.StatusMessage:
					StatusBorder.Background = new SolidColorBrush(Colors.Green);
					break;
				case NotifyType.ErrorMessage:
					StatusBorder.Background = new SolidColorBrush(Colors.Red);
					break;
			}

			StatusBlock.Text = message;

			StatusBorder.Visibility = (StatusBlock.Text != string.Empty) ? Visibility.Visible : Visibility.Collapsed;
			if(StatusBlock.Text != string.Empty)
			{
				StatusBorder.Visibility = Visibility.Visible;
				StatusPanel.Visibility = Visibility.Visible;
			}
			else
			{
				StatusBorder.Visibility = Visibility.Collapsed;
				StatusPanel.Visibility = Visibility.Collapsed;
			}
		}

		private void ScenarioListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			NotifyUser(string.Empty, NotifyType.StatusMessage);

			var scenarioList = sender as ListBox;
			Scenario s = scenarioList.SelectedItem as Scenario;

			if(s != null)
			{
				MainFrame.Navigate(s.PageType);
			}
		}
	}

	public enum NotifyType
	{
		StatusMessage,
		ErrorMessage
	}

}
