using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using mobi.Helper;
using mobi.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mobi.Activities
{
    [Activity(Label = "MOBIRice")]
    public class login_activity : Activity
    {
        EditText uEmail;
        EditText uPassword;
        Button login_btn;
        TextView resetpassbtn;
        TextView signupbtn;
        LinearLayout rootView;
   
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);

            ElementControl();       
        }

     
        void ElementControl()
        {
            uEmail = (EditText)FindViewById(Resource.Id.usr_email);
            uPassword = (EditText)FindViewById(Resource.Id.usr_pass);
            login_btn= (Button)FindViewById(Resource.Id.login_btn);
            resetpassbtn = (TextView)FindViewById(Resource.Id.usr_reset_pass);
            signupbtn = (TextView)FindViewById(Resource.Id.signup);
            rootView = (LinearLayout)FindViewById(Resource.Id.login_layout);

            login_btn.Click += Login_btn_Click;
            resetpassbtn.Click += Resetpassbtn_Click;
            signupbtn.Click += Signupbtn_Click;
                                
        }

        private void Signupbtn_Click(object sender, EventArgs e)
        {
            //WILL REDIRECT TO SIGNUP ACTIVITY
            StartActivity(typeof(signup_activity));
        
        }

        private void Resetpassbtn_Click(object sender, EventArgs e)
        {
            //WILL REDIRECT TO RESET ACTIVITY
            StartActivity(typeof(reset_activity));
        }


        private void Login_btn_Click(object sender, EventArgs e)
        {
            string email, password;
            email = uEmail.Text;
            password = uPassword.Text;

            //VALIDATE FOR EMAIL AND PASSWORD 
            if (!email.Contains("@"))
            {
                Toast.MakeText(rootView.Context, "Enter a valid Email",ToastLength.Short).Show();
                return;
            }
            else if (password.Length < 8)
            {
                Toast.MakeText(rootView.Context, "Password must be 8 Characters", ToastLength.Short).Show();
                return;
            }

            TaskListener TaskListener = new TaskListener();
            TaskListener.Success += TaskListener_Success;
            TaskListener.Failure += TaskListener_Failure;

            FirebaseAuth auth = AppDataHelper.GetFirebaseAuth();        
            auth.SignInWithEmailAndPassword(email, password)
                .AddOnSuccessListener(TaskListener)
                .AddOnFailureListener(TaskListener);
        
        
        }

        private void TaskListener_Failure(object sender, EventArgs e)
        {
            Toast.MakeText(rootView.Context, "Oops! something went wrong..", ToastLength.Short).Show();
        }

        private void TaskListener_Success(object sender, EventArgs e)
        {
            //IF LOGIN ACCEPTED IN SERVER WILL REDIRECT TO MAINACTIVITY
            StartActivity(typeof(MainActivity));
            
        }
    }
}