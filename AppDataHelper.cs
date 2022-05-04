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
using Firebase;
using Firebase.Auth;
using Firebase.Database;

namespace mobi.Helper
{
    public static class AppDataHelper
    {

       static ISharedPreferences preferences = Application.Context.GetSharedPreferences("userinfo", FileCreationMode.Private);

        public static FirebaseAuth GetFirebaseAuth()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseAuth usrAuth;
            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetApplicationId("riceapp-7cc68")
                    .SetApiKey("AIzaSyAcCfdI8BRptlBIxC79f6pGj4VpAeVbWcc")
                    .SetDatabaseUrl("https://riceapp-7cc68-default-rtdb.asia-southeast1.firebasedatabase.app")
                    .SetStorageBucket("riceapp-7cc68.appspot.com")
                    .Build();
                app = FirebaseApp.InitializeApp(Application.Context, options);
                usrAuth = FirebaseAuth.Instance;
            }
            else
            {
                usrAuth = FirebaseAuth.Instance;
            }
            return usrAuth;
        }

        public static FirebaseUser GetCurrentUser()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseAuth usrAuth;
            FirebaseUser user;
            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetApplicationId("riceapp-7cc68")
                    .SetApiKey("AIzaSyAcCfdI8BRptlBIxC79f6pGj4VpAeVbWcc")
                    .SetDatabaseUrl("https://riceapp-7cc68-default-rtdb.asia-southeast1.firebasedatabase.app")
                    .SetStorageBucket("riceapp-7cc68.appspot.com")
                    .Build();
                app = FirebaseApp.InitializeApp(Application.Context, options);
                usrAuth = FirebaseAuth.Instance;
                user = usrAuth.CurrentUser;
            }
            else
            {
                usrAuth = FirebaseAuth.Instance;
                user = usrAuth.CurrentUser;
            }
            return user;

        }

        public static FirebaseDatabase GetDatabase()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseDatabase database;
            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetApplicationId("riceapp-7cc68")
                    .SetApiKey("AIzaSyAcCfdI8BRptlBIxC79f6pGj4VpAeVbWcc")
                    .SetDatabaseUrl("https://riceapp-7cc68-default-rtdb.asia-southeast1.firebasedatabase.app")
                    .SetStorageBucket("riceapp-7cc68.appspot.com")
                    .Build();
                app = FirebaseApp.InitializeApp(Application.Context, options);
                database = FirebaseDatabase.GetInstance(app);
            }
            else
            {
               database = FirebaseDatabase.GetInstance(app);
            }
            return database;
        }

        public static string GetFullName()
        {
            string fullName = preferences.GetString("fullname", "");
            return fullName;
        }

        public static string GetEmail()
        {
            string email = preferences.GetString("email", "");
            return email;
        }

        public static string GetPhone()
        {
            string phone = preferences.GetString("phone", "");
            return phone;
        }
    }

}