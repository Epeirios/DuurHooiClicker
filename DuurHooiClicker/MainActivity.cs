using Android.App;
using Android.Widget;
using Android.OS;

namespace DuurHooiClicker
{
    [Activity(Label = "DuurHooiClicker", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var btnGame = FindViewById<Button>(Resource.Id.btnStartGame);
            btnGame.Click += btnGame_Click;


        }

        private void btnGame_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Game));
        }
    }
}

