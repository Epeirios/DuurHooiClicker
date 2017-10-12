
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DuurHooiClicker.DataClasses;
using System;
using System.Timers;

namespace DuurHooiClicker
{
    [Activity(Label = "Game")]
    public class Game : Activity
    {
        Timer t = new Timer();

        private static string hay = "Hay";
        private static string hayseeklevel = "HaySeek";
        private static string passivehayActive = "PassiveHay";

        private int passivehay = 1;

        TextView haylabel;
        ImageButton btnFindHay;
        Button btnHayCursus;
        Button btnPassiveHay;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Game);

            haylabel = FindViewById<TextView>(Resource.Id.HayLabel);

            //findhay button
            btnFindHay = FindViewById<ImageButton>(Resource.Id.FindHay);
            btnFindHay.Click += FindHay_Click;

            //findhay button
            btnHayCursus = FindViewById<Button>(Resource.Id.HayCursus);
            btnHayCursus.Click += HayCursus_Click;

            //passivehay button
            btnPassiveHay = FindViewById<Button>(Resource.Id.btnPassiveHay);
            btnPassiveHay.Click += PassiveHay_Click;

            //ResetSet();
            InitializeTimer();

            t.Enabled = Convert.ToBoolean(DataManager.Instance.RetrieveData(passivehayActive));            

            UpdateView();
        }

        private void PassiveHay_Click(object sender, EventArgs e)
        {
            t.Enabled = !t.Enabled;
            DataManager.Instance.SaveData(passivehayActive, Convert.ToInt32(t.Enabled));

            if (t.Enabled)
            {
                btnPassiveHay.Text = "Zoeken naar Passief Hooi";
            }
            else
            {
                AddHay(-100);

                btnPassiveHay.Text = "Hooi Zoeken? 100 Hooi!";
            }
        }

        private void InitializeTimer()
        {
            t.Interval = 1000;

            AddHay(passivehay);
            t.Elapsed += new ElapsedEventHandler(Timer_Tick);
        }

        private void AddHay(int amountofhay)
        {
            DataManager.Instance.SaveData(hay, DataManager.Instance.RetrieveData(hay) + amountofhay);
            UpdateView();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //do something here 
            RunOnUiThread(() => AddHay(passivehay));
            //AddHay(passivehay);
        }

        //basicseeker method
        private void HayCursus_Click(object sender, EventArgs e)
        {
            if (DataManager.Instance.RetrieveData(hay) >= 10)
            {
                int price = 10;
                DataManager.Instance.SaveData(hayseeklevel, DataManager.Instance.RetrieveData(hayseeklevel) + 1);
                AddHay(-1 * price);
            }
        }

        private void UpdateView()
        {
            haylabel.Text = "Hay: " + DataManager.Instance.RetrieveData(hay).ToString();
        }

        //findhay method
        private void FindHay_Click(object sender, EventArgs e)
        {
            AddHay(1 + DataManager.Instance.RetrieveData(hayseeklevel));
            UpdateView();
        }
    }
}