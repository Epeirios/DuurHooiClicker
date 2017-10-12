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
    public class DataObject
    {
        private string key;
        private int value;

        public string Key
        {
            get
            {
                return key;
            }
        }

        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        public DataObject(string key, int value = 0)
        {
            this.key = key;
            this.value = value;
        }
    }
}