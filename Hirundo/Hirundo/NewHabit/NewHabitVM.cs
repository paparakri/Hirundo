using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;

namespace Hirundo.NewHabit
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public ICommand ChangeText { set; get; }
        public ICommand SaveHabit { set; get; }
        public ViewModel()
        {
            ChangeText = new Command<string> (Change2Text);
            SaveHabit = new Command (SaveInfo);
        }

        public string IconText;

        public string newHabitName;
        public string NewHabitName
        {
            get => newHabitName;
            set
            {
                newHabitName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("NewHabitName"));
            }
        }

        public string newHabitQuantity;
        public string NewHabitQuantity
        {
            get => newHabitQuantity;
            set
            {
                newHabitQuantity = value;
                PropertyChanged(this, new PropertyChangedEventArgs("NewHabitQuantity"));
            }
        }

        public void Change2Text(string iconText)
        {
            IconText = iconText;
            Debug.WriteLine("===== " + IconText);
        }

        public void SaveInfo()
        {
            Debug.WriteLine("===== " + IconText + NewHabitName, NewHabitQuantity);
        }
    }
}
