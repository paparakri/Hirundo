using Hirundo.Helpers;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
using Hirundo.NewHabit;
using System.Windows.Input;

namespace Hirundo
{
	public partial class MainPage : ContentPage
	{
        SQLiteConnection database;
        public Action moveto_newtask;
        public ICommand GoToHabit { set; get; }

        public MainPage()
		{
            database = SQLite_Android.GetConnection();

            GoToHabit = new Command(MoveToTask);

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            moveto_newtask += () => App.Current.MainPage = new NavigationPage(new NewHabitPage());

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

            grid.RowDefinitions.Add(new RowDefinition());
            grid.Children.Add(new Button {
                Text = "New Task",
                Command = GoToHabit,
                BackgroundColor = Color.FromHex("#3aaa6a"),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = 25
            });
        }

        public List<Task> GetTasks()
        {
            return database.Table<Task>().ToList();
        }

        public void MoveToTask()
        {
            moveto_newtask();
        }
    }
}
