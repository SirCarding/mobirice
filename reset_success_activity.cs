using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mobi.Activities
{
    [Activity(Label = "MOBIRice")]
    public class reset_success_activity : Activity
    {
        Button loginReady;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_reset_success);

            loginReady = FindViewById<Button>(Resource.Id.logrest);
            loginReady.Click += LoginReady_Click;
        }

        private void LoginReady_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(login_activity));
        }
    }
}