﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;

namespace FindHayApp
{
    [Activity(Label = "FindHayApp", MainLauncher = true)]
    public class MainActivity : Activity
    {

        MediaPlayer _player;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //menu audio
            _player = MediaPlayer.Create(this, Resource.Raw.menutheme);
            _player.Start();

            var btnGame = FindViewById<Button>(Resource.Id.btnStartGame);
            btnGame.Click += btnGame_Click;


        }

        private void btnGame_Click(object sender, System.EventArgs e)
        {
            _player.Stop();
            StartActivity(typeof(Game));
        }
    }
}

