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
     /*
     TO DO:
     - days[N] binding not working in newhabit
     - toggle switch automatically if task is completed for today
     - delete task (set task.active=false)
     */
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
                    new RowDefinition() { Height=25 },
                    new RowDefinition() { Height=100 },
                    new RowDefinition() { Height=85 },
                },
                ColumnDefinitions = {
                    new ColumnDefinition() { Width=25 },
                    new ColumnDefinition() { Width=200 },
                    new ColumnDefinition() { Width=70 },
                    new ColumnDefinition() { Width=70 },
                    new ColumnDefinition() { Width=GridLength.Auto }
                }
            };

            //Get day of week 1-Monday, 7-Sunday
            int dayindex = ((int)DateTime.Now.DayOfWeek == 0) ? 7 : (int)DateTime.Now.DayOfWeek;
            string[] daynames = new string[7] {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"};
            string daystring = daynames[dayindex - 1];

            moveto_newtask += () => App.Current.MainPage = new NavigationPage(new NewHabitPage());

            var donetoggle = new Switch();
            var spacer = new BoxView();

            Label greet = new Label() {
                Text = String.Format("Hello, {0}.", Settings.GetUsername),
                TextColor = Color.FromHex("#3aaa6a"),
                FontSize = 32,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start
            };

            Label showday = new Label() {
                Text = String.Format("Today is {0}.", daystring),
                TextColor = Color.FromHex("#00b0cc"),
                FontSize = 24,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start
            };

            Grid.SetColumnSpan(greet, 3);
            Grid.SetColumnSpan(showday, 3);
            grid.Children.Add(greet, 1, 1);
            grid.Children.Add(showday, 1, 2);

            int rowcnt = 3;
            string taskdays = "";

            //Draw tasks
            foreach (var i in GetTasks()) {
                taskdays = "";
                for (int k = 0; k < 7; k++) {
                    if (i.daysofweek[k])
                        taskdays += daynames[k][0];
                    System.Diagnostics.Debug.WriteLine(i.daysofweek[k]);
                }
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                grid.Children.Add(new Label {
                    Text = i.title,
                    TextColor = Color.Black,
                    FontSize = 18,
                    Margin=10,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                }, 1, rowcnt);

                grid.Children.Add(new Label {
                    Text = taskdays,
                    TextColor = Color.FromHex("#00b0cc"),
                    FontSize = 18,
                    Margin = 10,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                }, 2, rowcnt);

                donetoggle = new Switch {
                    Margin = 10,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    VerticalOptions = LayoutOptions.StartAndExpand
                };

                grid.Children.Add(donetoggle, 3, rowcnt);

                rowcnt++;
            }

            //New task button
            grid.RowDefinitions.Add(new RowDefinition() { Height = 15 });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

            Button button = new Button {
                Text = "New Task",
                Command = GoToHabit,
                BackgroundColor = Color.FromHex("#cc2a45"),
                TextColor=Color.White,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.Start,
            };

            Grid.SetColumnSpan(button, 2);
            grid.Children.Add(button, 1, rowcnt+1);

            //Add cheesy quote
            var quote = new Label {
                Text = "\n\nThe way get Started is to quit talking and begin doing. \n\n– Walt Disney",
                FontSize = 14,
                FontAttributes = FontAttributes.Italic,
                TextColor = Color.Gray,
                VerticalOptions=LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End
            };

            Grid.SetColumnSpan(quote, 2);
            grid.Children.Add(quote, 1, rowcnt+2);

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