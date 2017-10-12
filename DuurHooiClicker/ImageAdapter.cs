using Android.Content;
using Android.Views;
using Android.Widget;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DuurHooiClicker
{
    public class ImageAdapter : BaseAdapter
    {
        Context context;

        private static string hay = "Hay";

        public ImageAdapter(Context c)
        {
            context = c;
        }
        //lengte moet ff gefixt worden
        public override int Count
        {
            get{ return 3; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        // create a new ImageView for each item referenced by the Adapter
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView imageView;

            if (convertView == null)
            {  // if it's not recycled, initialize some attributes
                imageView = new ImageView(context);
                imageView.LayoutParameters = new GridView.LayoutParams(350, 350);
                imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                imageView.SetPadding(8, 8, 8, 8);
            }
            else
            {
                imageView = (ImageView)convertView;
            }

            CheckAchievement();


            imageView.SetImageResource(thumbIds2[position]);

            return imageView;
        }

        //image list
        List<int> thumbIds2 = new List<int>();

        public void CheckAchievement()
        {
            //miljoen hooi
            int hayAmount = DataManager.Instance.RetrieveData(hay);

            int honderduizend = 100000;
            int miljoen = 1000000;
            int miljard = 1000000000;

            if(hayAmount >= honderduizend)
            {
                thumbIds2.Add(Resource.Drawable.achievement_honderdduizendhooi_enabled);
            }
            else
            {
                thumbIds2.Add(Resource.Drawable.achievement_honderdduizendhooi_disabled);
            }
            //miljoen hooi
            if (hayAmount >= miljoen)
            {
                thumbIds2.Add(Resource.Drawable.achievement_miljoenhooi_enabled);
            }
            else
            {
                thumbIds2.Add(Resource.Drawable.achievement_miljoenhooi_disabled);
            }

            //miljard hooi
            if(hayAmount >= miljard)
            {
                thumbIds2.Add(Resource.Drawable.achievement_miljardhooi_enabled);
            }
            else
            {
                thumbIds2.Add(Resource.Drawable.achievement_miljardhooi_disabled);
            }

        }
    }
}