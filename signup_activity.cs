using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Google.Android.Material.Snackbar;
using Java.Util;
using mobi.Helper;
using mobi.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mobi.Activities
{
    [Activity(Label = "MOBIRice")]
    public class signup_activity : Activity
    {
        EditText usr_fname;
        EditText usr_pnumber;
        EditText usr_email;
        EditText usr_password;
        EditText usr_conPass;
        Button register;
        TextView login;
        LinearLayout rootView;
        TaskListener TaskListener = new TaskListener();
        FirebaseAuth usrAuth = AppDataHelper.GetFirebaseAuth();


        string uEmail, uPassword, uFname, uPnumber, uPassVal;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.activity_signup);
            base.OnCreate(savedInstanceState);
            
            ElementLayout();
         
        }
   
        void ElementLayout()
        {
            usr_conPass = (EditText)FindViewById(Resource.Id.usr_passVal);
            usr_fname = (EditText)FindViewById(Resource.Id.usr_fname);
            usr_pnumber = (EditText)FindViewById(Resource.Id.usr_phone);
            usr_email = (EditText)FindViewById(Resource.Id.usr_email);
            usr_password = (EditText)FindViewById(Resource.Id.usr_pass);
            register = (Button)FindViewById(Resource.Id.register_btn);
            rootView = (LinearLayout)FindViewById(Resource.Id.register_layout);
            login = (TextView)FindViewById(Resource.Id.readyIN);
            
            register.Click += register_Click;
            login.Click += login_Click;
        }

        private void login_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(login_activity));
        }

        private void register_Click(object sender, EventArgs e)
        {
            uEmail = usr_email.Text;
            uPassword = usr_password.Text;
            uPnumber = usr_pnumber.Text;
            uFname = usr_fname.Text;
            uPassVal = usr_conPass.Text;

            if(uFname.Length < 3)
            {
                Snackbar.Make(rootView, "Please enter a valid name", Snackbar.LengthShort).Show();
                return;
            }
            else if (uFname.Contains("!`@#$%^&*()+=-[]\\\';,./{}|\":<>?~_"))
            {
                Snackbar.Make(rootView, "Special characters is not allowed", Snackbar.LengthShort).Show();
                return;
            }
            else if (!uEmail.Contains("@"))
            {
                Snackbar.Make(rootView, "Please enter a valid email", Snackbar.LengthShort).Show();
                return;
            }
            else if(uPnumber.Length < 11)
            {
                Snackbar.Make(rootView, "Please enter a valid Phone Number", Snackbar.LengthShort).Show();
                return;
            }
            else if (uPassword.Length < 8)
            {
                Snackbar.Make(rootView, "Password must be minimum 8 characters", Snackbar.LengthShort).Show();
                return;
            }
            else if(uPassVal != uPassword)
            {
                Snackbar.Make(rootView, "Password is not match!", Snackbar.LengthShort).Show();
                return;
            }

            registerUser(uEmail, uPassword);
        }

        void registerUser(string u_email, string u_password)
        {
            TaskListener.Success += TaskListener_Success;
            TaskListener.Failure += TaskListener_Failure;

            

            usrAuth.CreateUserWithEmailAndPassword(u_email, u_password)
                .AddOnFailureListener(this, TaskListener)
                .AddOnSuccessListener(this, TaskListener);
        }

        private void TaskListener_Failure(object sender, EventArgs e)
        {
            Toast.MakeText(rootView.Context, "SignUp Failed! Please try again later", ToastLength.Short).Show();
        }
        private void TaskListener_Success(object sender, EventArgs e)
        {
            
            Toast.MakeText(rootView.Context, "SignUp Successfully!", ToastLength.Short).Show();

            FirebaseDatabase database = AppDataHelper.GetDatabase();

            HashMap usrMap = new HashMap();
            usrMap.Put("fname",uFname);
            usrMap.Put("email", uEmail);
            usrMap.Put("phone", uPnumber);

            DatabaseReference userRef = database.GetReference("users/" + usrAuth.CurrentUser.Uid);
            userRef.SetValue(usrMap);

            StartActivity(typeof(login_activity));
            Finish();
        }


       

    }
}