
using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.Timers;

namespace DuurHooiClicker
{
    [Activity(Label = "Game")]
    public class Game : Activity
    {
        Timer t = new Timer();

        private int passivehay = 1;
        int AantalClicks = GameData.ClickCounter;


        TextView haylabel;
        ImageButton btnFindHay;
        Button btnHayCursus;
        Button btnPassiveHay;
        Button btnUpgradeHayCursus;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Game);
            GameData.HaycursusCost = 10;

            haylabel = FindViewById<TextView>(Resource.Id.HayLabel);

            //findhay button
            btnFindHay = FindViewById<ImageButton>(Resource.Id.FindHay);
            btnFindHay.Click += FindHay_Click;

            //findhay button
            btnHayCursus = FindViewById<Button>(Resource.Id.HayCursus);
            btnHayCursus.Click += HayCursus_Click;
            btnHayCursus.Text = "Follow hay cursus " + GameData.HaycursusCost;

            //passivehay button
            btnPassiveHay = FindViewById<Button>(Resource.Id.btnPassiveHay);
            btnPassiveHay.Click += PassiveHay_Click;

            //upgrade hay button
            btnUpgradeHayCursus = FindViewById<Button>(Resource.Id.btnUpgradeHayCursus);
            btnUpgradeHayCursus.Click += (s, arg) => {
                PopupMenu menu = new PopupMenu(this, btnUpgradeHayCursus);
                menu.Inflate(Resource.Menu.upgrade_hay_menu);
                menu.MenuItemClick += (s1, arg1) => {
                    Toast.MakeText(this, "Upgraded 10x", ToastLength.Short).Show();
                };

                menu.DismissEvent += (s2, arg2) =>
                {
                    Toast.MakeText(this, "Upgraded 25x.", ToastLength.Short).Show();
                };
                menu.Show();
            };

            //ResetSet();
            InitializeTimer();

            t.Enabled = GameData.PassiveHayActive;            

            UpdateView();
        }

        private void PassiveHay_Click(object sender, EventArgs e)
        {
            t.Enabled = !t.Enabled;
            GameData.PassiveHayActive = t.Enabled;

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
            GameData.Hay += amountofhay;
            UpdateView();
        }

        private void AddAantalClicks(int click)
        {
            GameData.ClickCounter += click;
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
            if (GameData.Hay >= GameData.HaycursusCost)
            {
                GameData.HayCursusGain += 1;
                AddHay(-1 * GameData.HaycursusCost);
                GameData.HaycursusCost = Cost_Updater(GameData.HaycursusCost, 1.1, 1);
                btnHayCursus.Text = "Follow hay cursus " + GameData.HaycursusCost;
            }
        }

        private void UpdateView()
        {
            haylabel.Text = "Hay: " + GameData.Hay.ToString();
        }

        //findhay method
        private void FindHay_Click(object sender, EventArgs e)
        {
            AddHay(GameData.HayCursusGain + 1);
            AddAantalClicks(1);
            UpdateView();
        }

        //cost updater
        private int Cost_Updater(Double value, Double rate, int count)
        {
            while(count > 0){
                value = value * rate;
                count--;
            }
            
            int outcome = (int)Math.Round(value, 0);
            return outcome;
        }


}
}
