using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Content;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace OpenWebpage2
{
    [Activity(Label = "OpenWebpage2", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Click += (sender,e) =>
            {
                var uri = Android.Net.Uri.Parse("http://ojc.asia");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };

        }
    }
}