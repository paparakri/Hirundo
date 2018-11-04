using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hirundo.NewHabit
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public ICommand DoneHabit { set; get; }
        public ViewModel()
        {
            DoneHabit = new Command (SaveInfo);
        }

        public bool monday;
        public bool Monday
        {
            get => monday;
            set
            {
                monday = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Monday"));
            }
        }
        public bool tuesday;
        public bool Tuesday
        {
            get => tuesday;
            set
            {
                tuesday = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Tuesday"));
            }
        }
        public bool wednesday;
        public bool Wednesday
        {
            get => wednesday;
            set
            {
                wednesday = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Wednesday"));
            }
        }
        public bool thursday;
        public bool Thursday
        {
            get => thursday;
            set
            {
                thursday = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Thursday"));
            }
        }
        public bool friday;
        public bool Friday
        {
            get => friday;
            set
            {
                friday = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Friday"));
            }
        }
        public bool saturday;
        public bool Saturday
        {
            get => saturday;
            set
            {
                saturday = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Saturday"));
            }
        }
        public bool sunday;
        public bool Sunday
        {
            get => sunday;
            set
            {
                sunday = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Sunday"));
            }
        }

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

        public void SaveInfo()
        {
            
        }
    }
}
