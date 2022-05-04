using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase;
using Firebase.Auth;
using Google.Android.Material.BottomNavigation;
using mobi.Activities;
using mobi.Helper;
using mobi.Listeners;
using System;
using ListFragment = mobi.Activities.ListFragment;

namespace mobi
{
    [Activity(Label = "MOBIRice", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        UserEventListener userEventListener = new UserEventListener();

        public static BottomNavigationView bottomnavigation;
       

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.activity_main);
                bottomnavigation = (BottomNavigationView)FindViewById(Resource.Id.bottom_navigation);
                bottomnavigation.NavigationItemSelected += Bottomnavigation_NavigationItemSelected;
                LoadFragment(Resource.Id.action_list);
            
               

                

            } catch (Exception ex) { }
            
        }

        private void Bottomnavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        public void LoadFragment(int id)
        {
            var frag = SupportFragmentManager.BeginTransaction(); 
            switch (id)
            {
                case Resource.Id.action_cart:
                    CartFragment cartFragment = new CartFragment();
                    frag.Replace(Resource.Id.landing_layout, cartFragment);
                    break;

                case Resource.Id.action_list:
                    ListFragment listFragment = new ListFragment();
                    frag.Replace(Resource.Id.landing_layout, listFragment);
                    break;

                case Resource.Id.action_user:
                    UserFragment userFragment = new UserFragment();
                    frag.Replace(Resource.Id.landing_layout,userFragment);
                    break;
            }
            frag.Commit();
        }
      

    }

}