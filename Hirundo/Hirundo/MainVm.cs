using Hirundo.Helpers;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using SQLite;

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
            Settings.GetUsername = Username;
            moveto_main();
        }
    }
}
