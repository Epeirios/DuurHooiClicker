
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Timers;

namespace DuurHooiClicker
{
    [Activity(Label = "Game")]
    public class Game : Activity
    {
        private int counter;
        Timer t = new Timer();


        private int hay;
        private int hayseeklevel = 0;
        private int passivehay = 1;
        private bool passivehayActive = false;

        private static string GameData = "GameData2";
        private static string hayPref = "Hay";
        private static string hayseeklevelPref = "HaySeek";
        private static string passivehayPref = "PassiveHay";

        TextView haylabel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Game);

            haylabel = FindViewById<TextView>(Resource.Id.HayLabel);


            //findhay button
            var FindHay = FindViewById<ImageButton>(Resource.Id.FindHay);
            FindHay.Click += FindHay_Click;

            //findhay button
            var HayCursus = FindViewById<Button>(Resource.Id.HayCursus);
            HayCursus.Click += HayCursus_Click;

            //ResetSet();
            InitializeTimer();
            RetrieveSet();

            if (passivehayActive)
            {
                t.Enabled = true;
            }

            UpdateView();
        }

        private void InitializeTimer()
        {
            counter = 0;
            t.Interval = 750;

            AddHay(passivehay);
            t.Elapsed += new ElapsedEventHandler(Timer_Tick);
        }

        private void AddHay(int amountofhay)
        {
            hay += amountofhay;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (counter >= 3)
            {
                t.Enabled = false;
            }
            else
            {
                //do something here 
                counter++;
                AddHay(passivehay);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            SaveSet();
        }

        //basicseeker method
        private void HayCursus_Click(object sender, EventArgs e)
        {
            if (hay >= 10)
            {
                int price = 10;
                hayseeklevel += 1;
                hay = hay - price;
                UpdateView();
            }
        }

        private void UpdateView()
        {
            haylabel.Text = "Hay: " + hay.ToString();
        }

        //findhay method
        private void FindHay_Click(object sender, EventArgs e)
        {
            hay += 1 + hayseeklevel;
            TextView haylabel = FindViewById<TextView>(Resource.Id.HayLabel);
            RunOnUiThread(() => hay = hay + passivehay);
            haylabel.Text = "Hay: " + hay.ToString();
        }

        // Function called from OnDestroy
        protected void SaveSet()
        {
            //store
            var prefs = Application.Context.GetSharedPreferences(GameData, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutInt(hayPref, hay);
            prefEditor.PutInt(hayseeklevelPref, hayseeklevel);
            prefEditor.PutBoolean(passivehayPref, passivehayActive);
            prefEditor.Commit();

            RunOnUiThread(() => Toast.MakeText(this, "Hooi ingegraven!", ToastLength.Short).Show());
        }

        // Function called from OnCreate
        protected void RetrieveSet()
        {
            //retreive 
            var prefs = Application.Context.GetSharedPreferences(GameData, FileCreationMode.Private);
            hay = prefs.GetInt(hayPref, 0); // Default value is 0
            hayseeklevel = prefs.GetInt(hayseeklevelPref, 0); // Default value is 0
            passivehayActive = prefs.GetBoolean(passivehayPref, false);

            RunOnUiThread(() => Toast.MakeText(this, "Hooi opgegraven!", ToastLength.Short).Show());
        }

        private void ResetSet()
        {
            // Reset
            var prefs = Application.Context.GetSharedPreferences(GameData, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutInt(hayPref, 0);
            prefEditor.PutInt(hayseeklevelPref, 0);
            prefEditor.PutBoolean(passivehayPref, false);
            prefEditor.Commit();

            RunOnUiThread(() => Toast.MakeText(this, "Hooi verkocht!", ToastLength.Short).Show());
        }
    }
}