using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
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
    public class UserFragment : AndroidX.Fragment.App.Fragment 
    {

        //USER FRAGMENT DASHBOARD
        View view;
        TextView fullname, email, phone;
        Button btnLogout;
        FirebaseAuth auth;
        public override View OnCreateView(LayoutInflater inflater,ViewGroup container,Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.user_layout,container,false);
            
            fullname = (TextView)view.FindViewById(Resource.Id.f_Name);
            email = (TextView)view.FindViewById(Resource.Id.u_Email);
            phone = (TextView)view.FindViewById(Resource.Id.usr_pnumber);
            btnLogout = (Button)view.FindViewById(Resource.Id.logout_btn);
            btnLogout.Click += BtnLogout_Click;

            //READ THE USER INFO FROM AppDataHelper
            fullname.Text = AppDataHelper.GetFullName();
            email.Text = AppDataHelper.GetEmail();
            phone.Text = AppDataHelper.GetPhone();

            return view;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
         

            auth = AppDataHelper.GetFirebaseAuth();
            auth.SignOut();

            Intent i = new Intent(Application.Context, Java.Lang.Class.FromType(typeof(login_activity)));
            StartActivity(i);

        }
      
    }
}