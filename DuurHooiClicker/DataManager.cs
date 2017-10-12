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
        private DataObject hay = new DataObject(DataTypes.Hay);
        private DataObject aantalclicks = new DataObject(DataTypes.ClickCounter);
        private DataObject hayseeklevel = new DataObject(DataTypes.HaySeekerLevel);
        private DataObject passivehayActive = new DataObject(DataTypes.PassiveHayActive);

        private static string GameData = "GameData";

        private static DataManager instance;

        private DataManager()
        {
            hay.Value = GetData(DataTypes.Hay);
            aantalclicks.Value = GetData(DataTypes.ClickCounter);
            hayseeklevel.Value = GetData(DataTypes.HaySeekerLevel);
            passivehayActive.Value = GetData(DataTypes.PassiveHayActive);
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

        public void SetData(DataTypes key, int value)
        {
            // Store Data
            var prefs = Application.Context.GetSharedPreferences(GameData, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutInt(key.ToString(), value);
            prefEditor.Commit();
        }

        // Function called from OnCreate
        public int GetData(DataTypes key)
        {
            DataObject data = new DataObject(key);

            // Retrieve 
            var prefs = Application.Context.GetSharedPreferences(GameData, FileCreationMode.Private);
            return prefs.GetInt(data.Key.ToString(), 0); // Default value is 0
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