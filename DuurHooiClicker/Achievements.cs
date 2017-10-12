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
            };
                
            
        }
    }
}