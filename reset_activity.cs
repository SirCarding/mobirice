using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using mobi.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mobi.Activities
{
    [Activity(Label = "MOBIRice")]
    public class reset_activity : Activity
    {
        EditText email;
        Button reset_pass_btn;
        TextView register;
        FirebaseAuth uAuth;
        LinearLayout reset_view;
        string usremail;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.activity_reset_password);
            ElementControl();
            InitializeFirebase();
        }
        void InitializeFirebase()
        {
            var app = FirebaseApp.InitializeApp(this);
            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                   .SetApplicationId("riceapp-7cc68")
                   .SetApiKey("AIzaSyAcCfdI8BRptlBIxC79f6pGj4VpAeVbWcc")
                   .SetDatabaseUrl("https://riceapp-7cc68-default-rtdb.asia-southeast1.firebasedatabase.app")
                   .SetStorageBucket("riceapp-7cc68.appspot.com")
                   .Build();
                app = FirebaseApp.InitializeApp(this, options);
                uAuth = FirebaseAuth.Instance;
            }else
            uAuth = FirebaseAuth.Instance;
        }

        void ElementControl()
        {
            email = (EditText)FindViewById(Resource.Id.send_email);
            reset_pass_btn = (Button)FindViewById(Resource.Id.reset_pass_btn);
            register = (TextView)FindViewById(Resource.Id.signup_btn);
            reset_view = (LinearLayout)FindViewById(Resource.Id.reset_layout);

            reset_pass_btn.Click += Reset_pass_btn_Click;
            register.Click += Register_Click;
        }

        private void Register_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(signup_activity));
        }

        private void Reset_pass_btn_Click(object sender, EventArgs e)
        {
            usremail = email.Text;
            TaskListener taskListener = new TaskListener();
            uAuth.SendPasswordResetEmail(usremail)
                .AddOnSuccessListener(taskListener)
                .AddOnFailureListener(taskListener);

            taskListener.Success += TaskListener_Success;
            taskListener.Failure += TaskListener_Failure;

            
            


        }

        private void TaskListener_Failure(object sender, EventArgs e)
        {
           Toast.MakeText(reset_view.Context,"Oops! something went wrong..", ToastLength.Short).Show();
            
        }

        private void TaskListener_Success(object sender, EventArgs e)
        {
            StartActivity(typeof(reset_success_activity));
            Finish();
        }
    }
}