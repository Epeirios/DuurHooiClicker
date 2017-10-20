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
        private static string pref = "GameData";

        public static int Hay
        {         
            get
            {
                return Get(DataTypes.Hay);
            }
            set
            {
                Set(DataTypes.Hay, value);
            }
        }

        public static int ClickCounter
        {
            get
            {
                return Get(DataTypes.ClickCounter);
            }
            set
            {
                Set(DataTypes.ClickCounter, value);
            }
        }

        public static int HayCursusGain
        {
            get
            {
                return Get(DataTypes.HayCursusGain);
            }
            set
            {
                Set(DataTypes.HayCursusGain, value);
            }
        }

        public static int HaycursusCost
        {
            get
            {
                return Get(DataTypes.HaycursusCost);
            }
            set
            {
                Set(DataTypes.HaycursusCost, value);
            }
        }

        public static bool PassiveHayActive
        {
            get
            {
                return Convert.ToBoolean(Get(DataTypes.PassiveHayActive));
            }
            set
            {
                Set(DataTypes.PassiveHayActive, Convert.ToInt32(value));
            }
        }

        public static int BuyAmount
        {
            get
            {
                return Get(DataTypes.BuyAmount);
            }
            set
            {
                Set(DataTypes.BuyAmount, value);
            }
        }

        private static int Get(DataTypes type)
        {
            return DataManager.Instance.GetData(type, pref);
        }

        private static void Set(DataTypes type, int value)
        {
            DataManager.Instance.SetData(type, value, pref);
        }
    }
}