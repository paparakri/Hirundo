using Plugin.LocalNotifications;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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
    public class Task
    {
        [SQLite.PrimaryKey]
        public string title { get; set; }

        public bool monday { get; set; }
        public bool tuesday { get; set; }
        public bool wednesday { get; set; }
        public bool thursday { get; set; }
        public bool friday { get; set; }
        public bool saturday { get; set; }
        public bool sunday { get; set; }
        public int timesDone { get; set; }
    }
    public static class SQLite_Android
    {
        public static SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TasksDatabase.db3";
            string documentPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqliteFileName);
            var conn = new SQLiteConnection(path);

            return conn;
        }
    }
}
