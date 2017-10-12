using Android.App;
using Android.OS;
using Android.Widget;

namespace DuurHooiClicker
{
    [Activity(Label = "Achievements")]
    public class Achievements : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Achievements);
            var gridview = FindViewById<GridView>(Resource.Id.gridAchievements);
            gridview.Adapter = new ImageAdapter(this);

            gridview.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                //100.000 hay achievment
                if(args.Position == 0)
                {
                    Toast.MakeText(this, "Collect 100.000 hay.", ToastLength.Short).Show();
                }
                //1.000.000 hay achievment
                if (args.Position == 1)
                {
                    Toast.MakeText(this, "Collect 1.000.000 hay.", ToastLength.Short).Show();
                }
                //1.000.000.000 hay achievment
                if (args.Position == 2)
                {
                    Toast.MakeText(this, "Collect 1.000.000.000 hay.", ToastLength.Short).Show();
                }
                
                //1.000 clicks
                if (args.Position == 3)
                {
                    Toast.MakeText(this, "Click hay 1.000 times.", ToastLength.Short).Show();
                }
                //10.000 clicks
                if (args.Position == 4)
                {
                    Toast.MakeText(this, "Click hay 10.000 times.", ToastLength.Short).Show();
                }
                //100.000 clicks
                if (args.Position == 5)
                {
                    Toast.MakeText(this, "Click hay 100.000 times.", ToastLength.Short).Show();
                }
            };
                
            
        }
    }
}