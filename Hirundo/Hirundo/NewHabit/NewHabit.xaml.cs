using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hirundo.NewHabit
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewHabitPage : ContentPage
	{
		public NewHabitPage ()
        {
            var view_model = new ViewModel();
            BindingContext = view_model;
            InitializeComponent ();
        }
        private async void ShowPopup(object o, EventArgs e)
        {
            var popup = new PopUpPage();
            await base.Navigation.PushPopupAsync(popup);
        }
    }
}