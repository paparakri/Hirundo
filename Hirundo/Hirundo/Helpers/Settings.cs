using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Hirundo.Helpers
{
   public static class Settings
   {
       private static ISettings AppSettings
       {
           get {
               return CrossSettings.Current;
           }
       }

       #region Setting Constants

       private const string SettingsKey = "settings_key";
       private static readonly string SettingsDefault = string.Empty;

       #endregion

       #region Name
       private const string Username = "";
       private static readonly string UsernameDefault = "";
       #endregion

       public static string GeneralSettings
       {
           get {
               return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
           }
           set {
               AppSettings.AddOrUpdateValue(SettingsKey, value);
           }
       }

       public static string GetUsername
       {
           get {
               return AppSettings.GetValueOrDefault(Username, UsernameDefault);
           }
           set {
               AppSettings.AddOrUpdateValue(Username, value);
           }
       }
   }
}

