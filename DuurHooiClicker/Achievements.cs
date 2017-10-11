using Android.App;
using Android.OS;
using Android.Widget;

namespace DuurHooiClicker
{
    [Activity(Label = "Achievements")]
    public class Achievements : Activity
    {

        bool achievment_miljoenhooi = false;
        bool achievement_mijardhooi = false;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Achievements);
            var gridview = FindViewById<GridView>(Resource.Id.gridAchievements);
            gridview.Adapter = new ImageAdapter(this);

            gridview.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(this, args.Position.ToString(), ToastLength.Short).Show();
            };
                
            
        }
    }
}