using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using mobi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mobi.Listeners
{
    public class UserEventListener : Java.Lang.Object, IValueEventListener
    {
        ISharedPreferences preferences = Application.Context.GetSharedPreferences("userinfo", FileCreationMode.Private);
        ISharedPreferencesEditor editor;
        public void OnCancelled(DatabaseError error)
        {
           
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
           if(snapshot != null)
            {
                string fullname, email, phone = "";
                fullname = (snapshot.Child("fname") != null) ? snapshot.Child("fname").Value.ToString() : "";
                email = (snapshot.Child("email") != null) ? snapshot.Child("email").Value.ToString() : "";
                if(snapshot.Child("phone") != null)
                {
                    phone = snapshot.Child("phone").Value.ToString();
                }

                editor.PutString("fullname",fullname);
                editor.PutString("email", email);
                editor.PutString("phone", phone);
                editor.Apply();
            }
        }

        public void Create()
        {
            editor = preferences.Edit();
            FirebaseDatabase database = AppDataHelper.GetDatabase();
            string userID = AppDataHelper.GetCurrentUser().Uid;

            DatabaseReference profileReferece = database.GetReference("users/" + userID);
            profileReferece.AddValueEventListener(this);
        }
    }
}