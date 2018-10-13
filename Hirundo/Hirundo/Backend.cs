using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace Hirundo
{
    public class Backend
    {
        public void Notification(string Title, string Body, int NotifId, DateTime dt)
        {
            CrossLocalNotifications.Current.Show(Title, Body, NotifId, dt);
        }
    }
}
