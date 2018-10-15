using Hirundo.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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
        
        public string DisplayName = "Hello, "+Settings.GetUsername;
        public void SaveName()
        {
            Settings.GetUsername = Username;
            moveto_main();
        }
    }
}
