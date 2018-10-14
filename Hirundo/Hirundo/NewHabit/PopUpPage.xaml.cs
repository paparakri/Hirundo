using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;
using System.Diagnostics;
using Rg.Plugins.Popup.Services;

namespace Hirundo.NewHabit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopUpPage : PopupPage
	{
		public PopUpPage ()
		{
            var view_model = new ViewModel();
            BindingContext = view_model;
            InitializeComponent ();
		}
        
        public void ClosePopup(object sender, System.EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(true);
        }
	}
}