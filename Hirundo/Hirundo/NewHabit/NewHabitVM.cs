using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hirundo.NewHabit
{

    public class SQLiteController
    {
        SQLiteConnection database;

        public SQLiteController()
        {
            database = SQLite_Android.GetConnection();
        }
        public bool SaveTask(Task task)
        {
            try
            {
                database.Insert(task);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("===== " + ex);
                return false;
            }
        }

        public Task GetTask()
        {
            return database.Table<Task>().First();
        }
    }

    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public ICommand DoneHabit { set; get; }
        public ViewModel()
        {
            DoneHabit = new Command(SaveInfo);
        }

        public bool[] days = new bool[7];
        public string newHabitName;
        public string NewHabitName
        {
            get => newHabitName;
            set {
                newHabitName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("NewHabitName"));
            }
        }

        public void SaveInfo()
        {
            SQLiteController controller = new SQLiteController();

            Task newTask = new Task {
                title = NewHabitName
            };

            for (int i = 0; i < 7; i++)
                newTask.daysofweek[i] = days[i];

            controller.SaveTask(newTask);
            App.Current.MainPage = new MainPage();
        }
    }
}