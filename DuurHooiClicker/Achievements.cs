using Android.App;
using Android.OS;

namespace DuurHooiClicker
{
    [Activity(Label = "Achievements")]
    internal class Achievements : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Achievements);
        }
    }
}