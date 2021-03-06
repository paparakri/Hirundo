using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hirundo.Helpers;
using Hirundo.Setup;
using Hirundo.NewHabit;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Hirundo
{
	public partial class App : Application
	{
		public App ()
		{
            if (Settings.GetUsername == "") {
                MainPage = new SetupPage();
            }
            else {
                System.Diagnostics.Debug.WriteLine("=====" + Settings.GetUsername);
                MainPage = new NavigationPage(new TasksPage.TasksPage());
            }

            InitializeComponent();
        }
	}
}
