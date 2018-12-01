using Hirundo.Helpers;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using SQLite;
using System.IO;
using Hirundo;

[assembly: Dependency(typeof(SQLite_Android))]

namespace Hirundo
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Action moveto_main;
        public ICommand SubmitName { set; get; }

        public ViewModel()
        {
            SubmitName = new Command(SaveName);
        }

        private string username;
        public string Username
        {
            get => username;
            set {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        public void SaveName()
        {
            SQLiteConnection database;
            database = SQLite_Android.GetConnection();
            database.CreateTable<Task>();
            
            Settings.GetUsername = Username;
            moveto_main();
        }
    }
}
