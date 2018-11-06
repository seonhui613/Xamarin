using Android.App;
using Android.Text;
using Android.Content;
using Android.OS;
using System;
using System.Collections.Generic;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace Hello
{
    [Activity(Label = "Xamarin in Android",MainLauncher = true)]
    public class MainActivity : Activity
    {
        static readonly List<string> phoneNymbers = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button callHistoryButton = FindViewById<Button>(Resource.Id.CallHistoryButton);
            callHistoryButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(CallHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNymbers);
                StartActivity(intent);
            };

            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);

            Button callButton = FindViewById<Button>(Resource.Id.CallButton);
            callButton.Enabled = false;

            phoneNumberText.TextChanged +=
                (object sender, TextChangedEventArgs e) =>
                {
                    if (!string.IsNullOrWhiteSpace(phoneNumberText.Text))
                        callButton.Enabled = true;
                    else
                        callButton.Enabled = false;
                };

            callButton.Click += (object sender, EventArgs e) =>
            {
                var callDialog = new Android.App.AlertDialog.Builder(this);
                callDialog.SetMessage("Call" + phoneNumberText.Text + "?");

                callDialog.SetNeutralButton("Call", delegate
                {
                    phoneNymbers.Add(phoneNumberText.Text);
                    callHistoryButton.Enabled = true;

                    var callIntent = new Intent(Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse("tel : " + phoneNumberText.Text));
                    StartActivity(callIntent);
                });

                callDialog.SetNegativeButton("Cancel", delegate { });
                callDialog.Show();
            };

        }
    }
}