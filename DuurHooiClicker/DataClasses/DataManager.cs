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

namespace DuurHooiClicker.DataClasses
{
    class DataManager
    {
        private static DataManager instance;

        private DataManager() { }

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

        public void SetData(DataTypes key, int value, string pref)
        {
            // Store Data
            var prefs = Application.Context.GetSharedPreferences(pref, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutInt(key.ToString(), value);
            prefEditor.Commit();
        }

        // Function called from OnCreate
        public int GetData(DataTypes key, string pref)
        {
            DataObject data = new DataObject(key);

            // Retrieve 
            var prefs = Application.Context.GetSharedPreferences(pref, FileCreationMode.Private);
            return prefs.GetInt(data.Key.ToString(), 0); // Default value is 0
        }

        // Hard Reset for all Saved Data in Pref
        public void ResetData(string pref)
        {
            var prefs = Application.Context.GetSharedPreferences(pref, FileCreationMode.Private);
            var prefEditor = prefs.Edit();

            foreach (DataTypes item in Enum.GetValues(typeof(DataTypes)))
            {
                prefEditor.PutInt(item.ToString(), 0);
            }

            prefEditor.Commit();
        }
    }
}