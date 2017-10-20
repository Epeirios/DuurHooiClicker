
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using System.Timers;

namespace DuurHooiClicker
{
    [Activity(Label = "DuurHooiClicker", MainLauncher = true)]
    public class Game : Activity
    {
        Timer t = new Timer();

        private int passivehay = 1;
        int AantalClicks = GameData.ClickCounter;



        TextView haylabel;
        TextView testview;
        ImageButton btnFindHay;
        Button btnHayCursus;
        Button btnPassiveHay;
        Button btnBuyAmount;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Create your application here
            SetContentView(Resource.Layout.Game);
            base.OnCreate(savedInstanceState);
            
            //toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Hay clicker";

            haylabel = FindViewById<TextView>(Resource.Id.HayLabel);
            testview = FindViewById<TextView>(Resource.Id.testview);
            GameData.BuyAmount = 1;
            testview.Text = GameData.BuyAmount.ToString();

            //buyamount button
            btnBuyAmount = FindViewById<Button>(Resource.Id.btnBuyAmount);
            btnBuyAmount.Click += BuyAmount_Click;

            //findhay button
            btnFindHay = FindViewById<ImageButton>(Resource.Id.FindHay);
            btnFindHay.Click += FindHay_Click;

            //findhay button
            btnHayCursus = FindViewById<Button>(Resource.Id.HayCursus);
            btnHayCursus.Click += HayCursus_Click;
            if (GameData.HaycursusCost == 0)
            {
                GameData.HaycursusCost = 10;
            }
            else
            {
                btnHayCursus.Text = "Follow hay cursus: " + GameData.HaycursusCost;
            }

            //passivehay button
            btnPassiveHay = FindViewById<Button>(Resource.Id.btnPassiveHay);
            btnPassiveHay.Click += PassiveHay_Click;

            //ResetSet();
            InitializeTimer();

            t.Enabled = GameData.PassiveHayActive;            

            UpdateView();
        }

        private void OpenAchievementActivity()
        {
            StartActivity(typeof(Achievements));
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

        //follow haycursus
        private void HayCursus_Click(object sender, EventArgs e)
        {
            
            if (GameData.Hay >= GameData.HaycursusCost)
            {
                GameData.HayCursusGain = GameData.HayCursusGain + GameData.BuyAmount;
                //dit moet je fixen 
                AddHay(-1 * GameData.HaycursusCost);
                GameData.HaycursusCost = Cost_Updater(GameData.HaycursusCost, 1.1, GameData.BuyAmount);
                btnHayCursus.Text = "Follow hay cursus " + GameData.HaycursusCost;
            }
        }

        //buyamount
        private void BuyAmount_Click(object sender, EventArgs e)
        {
            btnBuyAmount = FindViewById<Button>(Resource.Id.btnBuyAmount);

            
            bool stop = false;
            if (GameData.BuyAmount == 1 && stop == false)
            {
                stop = true;
                GameData.BuyAmount = 10;
            }
            if (GameData.BuyAmount == 10 && stop == false)
            {
                stop = true;
                GameData.BuyAmount = 25;
            }
            if (GameData.BuyAmount == 25 && stop == false)
            {
                stop = true;
                GameData.BuyAmount = 50;
            }
            if (GameData.BuyAmount == 50 && stop == false)
            {
                stop = true;
                GameData.BuyAmount = 100;
            }
            if (GameData.BuyAmount == 100 && stop == false)
            {
                stop = true;
                GameData.BuyAmount = 1;
            }
            testview.Text = GameData.BuyAmount.ToString();


            int x = 0;
            int amount = GameData.BuyAmount-1;
            double price = GameData.HaycursusCost;
            double totaal = price;

            while(x < amount)
            {
                x++;
                totaal = totaal + price * 1.1;
                price = price * 1.1;

                price = (int)Math.Round(price);
                totaal = (int)Math.Round(totaal);
            }
            //double price = GameData.HaycursusCost;
            //double amount = GameData.BuyAmount;


            //price = GameData.HaycursusCost * Math.Pow(1.1, amount-1);
            //price = (int)Math.Round(price);

            btnHayCursus.Text = "Follow hay cursus: " + totaal.ToString();
            //GameData.BuyAmount = amount;
            btnBuyAmount.Text = GameData.BuyAmount.ToString() + "x";
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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if(item.TitleFormatted.ToString() == "Achievements")
            {
                StartActivity(typeof(Achievements));
            }
            return base.OnOptionsItemSelected(item);
        }


    }
}
