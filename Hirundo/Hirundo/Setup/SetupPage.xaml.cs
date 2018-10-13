using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hirundo.Setup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SetupPage : ContentPage
	{
		public SetupPage ()
		{
            var view_model = new ViewModel();
            BindingContext = view_model;

            view_model.moveto_main += () => App.Current.MainPage = new MainPage();

            InitializeComponent ();
		}
	}
}