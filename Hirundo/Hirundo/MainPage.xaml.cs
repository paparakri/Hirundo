using Hirundo.Helpers;
using System;
using System.Collections.Generic;
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

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            int rowcnt = 1;
            Switch donetoggle;
            Label greet = new Label() {
                Text = String.Format("Hello, {0}.", Settings.GetUsername),
                TextColor = Color.FromHex("#3aaa6a")
            };
            
            foreach (Task i in GetTasks()) {
                grid.RowDefinitions.Add(new RowDefinition());

                if (i.DoneToday)
                    System.Diagnostics.Debug.WriteLine("Completed task " + i.title);
                else System.Diagnostics.Debug.WriteLine("Remaining task " + i.title);

                grid.Children.Add(new Label { Text = i.title,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand }, rowcnt, 0);

                donetoggle = new Switch {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };

                grid.Children.Add(donetoggle, rowcnt, 1);

                rowcnt++;
            }
		}

        public List<Task> GetTasks()
        {
            return database.Table<Task>().ToList();
        }
    }
}
