using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DuurHooiClicker.DataClasses;

namespace DuurHooiClicker
{
    public class DataManager
    {
        private DataObject hay = new DataObject("Hay");
        private DataObject aantalclicks = new DataObject("Aantalclicks");
        private DataObject hayseeklevel = new DataObject("HaySeek");
        private DataObject passivehayActive = new DataObject("PassiveHay");

        private static string GameData = "GameData";

        private static DataManager instance;

        private DataManager()
        {
            hay.Value = RetrieveData("Hay");
            aantalclicks.Value = RetrieveData("Aantalclicks");
            hayseeklevel.Value = RetrieveData("HaySeek");
            passivehayActive.Value = RetrieveData("PassiveHay");
        }

        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataManager();
                }
                return instance;
            }
        }

        public void SaveData(string key, int value)
        {
            // Store Data
            var prefs = Application.Context.GetSharedPreferences(GameData, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutInt(key, value);
            prefEditor.Commit();
        }

        // Function called from OnCreate
        public int RetrieveData(string key)
        {
            DataObject data = new DataObject(key);

            // Retrieve 
            var prefs = Application.Context.GetSharedPreferences(GameData, FileCreationMode.Private);
            return prefs.GetInt(data.Key, 0); // Default value is 0
        }

        private void ResetData()
        {
            // TODO

            // Reset
            var prefs = Application.Context.GetSharedPreferences(GameData, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            //prefEditor.PutInt(hayPref, 0);
            prefEditor.Commit();
        }
    }
}