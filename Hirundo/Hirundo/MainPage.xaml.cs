using Hirundo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace Hirundo
{
	public partial class MainPage : ContentPage
	{
        SQLiteConnection database;
        public MainPage()
		{
            database = SQLite_Android.GetConnection();
            var view_model = new ViewModel();
            BindingContext = view_model;

            InitializeComponent();
		}

        public List<Task> GetTasks()
        {
            return database.Table<Task>().ToList();
        }

    }
}
