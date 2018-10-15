using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamForms.Controls;

namespace Hirundo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            var view_model = new CalendarVM();
            BindingContext = view_model;
            
            InitializeComponent();
            
            new Calendar
            {
                BorderColor = Color.Black,
                BorderWidth = 3,
                BackgroundColor = Color.Black,
                StartDay = DayOfWeek.Sunday,
                StartDate = DateTime.Now
            };
        }
    }
}
