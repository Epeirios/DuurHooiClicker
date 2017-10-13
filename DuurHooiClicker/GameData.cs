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
    public static class GameData
    {
        public static int Hay
        {
            get
            {
                return DataManager.Instance.GetData(DataTypes.Hay);
            }
            set
            {
                DataManager.Instance.SetData(DataTypes.Hay, value);
            }
        }

        public static int ClickCounter
        {
            get
            {
                return DataManager.Instance.GetData(DataTypes.ClickCounter);
            }
            set
            {
                DataManager.Instance.SetData(DataTypes.ClickCounter, value);
            }
        }

        public static int HaySeekerLevel
        {
            get
            {
                return DataManager.Instance.GetData(DataTypes.HaySeekerLevel);
            }
            set
            {
                DataManager.Instance.SetData(DataTypes.HaySeekerLevel, value);
            }
        }

        public static int haycursus_cost
        {
            get
            {
                return DataManager.Instance.GetData(DataTypes.haycursus_cost);
            }
            set
            {
                DataManager.Instance.SetData(DataTypes.haycursus_cost, value);
            }
        }

        public static bool PassiveHayActive
        {
            get
            {
                return Convert.ToBoolean(DataManager.Instance.GetData(DataTypes.PassiveHayActive));
            }
            set
            {
                DataManager.Instance.SetData(DataTypes.PassiveHayActive, Convert.ToInt32(value));
            }
        }
    }
}