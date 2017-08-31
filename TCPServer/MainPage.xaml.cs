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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TCPServer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			AppTitle.Text = APP_TITLE;

		}
	}

	public class ScenarioNameListConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var scenario = value as Scenario;
			return scenario.Title;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return true;
		}
	}

	public class ScenarioIconListConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var scenario = value as Scenario;
			return scenario.Icon;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return true;
		}
	}
}
