using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hirundo.Helpers;

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
                MainPage = new MainPage();
            }

            InitializeComponent();
        }
	}
}
