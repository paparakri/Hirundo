using Hirundo.Helpers;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
using Xamarin.Forms.Xaml;
using Hirundo.NewHabit;
using System.Windows.Input;


namespace Hirundo.TasksPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TasksPage : ContentPage
	{
        SQLiteConnection database;
        public Action moveto_newtask;
        public ICommand GoToHabit { set; get; }

        public TasksPage ()
		{
            InitializeComponent();

            System.Diagnostics.Debug.WriteLine("===== IN TASKS PAGE");
            database = SQLite_Android.GetConnection();

            GoToHabit = new Command(MoveToTask);

            var grid = new Grid() {
                RowDefinitions = {
                    new RowDefinition() { Height=GridLength.Auto },
                    new RowDefinition() { Height=75 },
                },
                ColumnDefinitions = {
                    new ColumnDefinition() { Width=15 },
                    new ColumnDefinition() { Width=GridLength.Auto },
                    new ColumnDefinition() { Width=75 },
                    new ColumnDefinition() { Width=50 },
                    new ColumnDefinition() { Width=15 }
                }
            };

            moveto_newtask += () => App.Current.MainPage = new NavigationPage(new NewHabitPage());

            var donetoggle = new Switch();

            Label greet = new Label() {
                Text = String.Format("Hello, {0}.", Settings.GetUsername),
                TextColor = Color.FromHex("#3aaa6a"),
                FontSize = 32,
                Margin=25,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start
            };

            Grid.SetColumnSpan(greet, 2);
            grid.Children.Add(greet, 1, 1);

            int rowcnt = 2;

            //Draw tasks
            foreach (var i in GetTasks()) {
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                if (i.DoneToday)
                    System.Diagnostics.Debug.WriteLine("Completed task " + i.title);
                else System.Diagnostics.Debug.WriteLine("Remaining task " + i.title);

                grid.Children.Add(new Label {
                    Text = i.title,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                }, 1, rowcnt);

                donetoggle = new Switch {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };

                grid.Children.Add(donetoggle, 2, rowcnt);
                rowcnt++;
            }

            //New task button
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

            Button button = new Button {
                Text = "New Task",
                Command = GoToHabit,
                BackgroundColor = Color.FromHex("#3aaa6a"),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = 25
            };

            Grid.SetColumnSpan(button, 2);
            grid.Children.Add(button, 1, rowcnt);

            var scrollView = new ScrollView {
                Content = grid
            };

            this.Content = scrollView;
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