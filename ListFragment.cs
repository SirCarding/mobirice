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
    [Activity(Label = "ListFragment")]
    public class ListFragment : AndroidX.Fragment.App.Fragment
    {



        private JavaList<Rice> rice;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
         
            View view = inflater.Inflate(Resource.Layout.list_layout, container, false);
            var ListViewItem = view.FindViewById<ListView>(Resource.Id.listView1);

           //ListView Bind for Rice Items
            ListViewItem.Adapter = new CustomAdapter(this.Context as Activity, GetRices());

            return view;

                         
           }

        private JavaList<Rice> GetRices()
        {
            rice = new JavaList<Rice>();
            Rice s;

            s = new Rice("Basmati", Resource.Drawable.basmati_longrice);
            rice.Add(s);
           
            s = new Rice("Jasponica", Resource.Drawable.basmati_longrice);
            rice.Add(s);
           
            s = new Rice("Sakura", Resource.Drawable.basmati_longrice);
            rice.Add(s);

            s = new Rice("Spanish Gate", Resource.Drawable.basmati_longrice);
            rice.Add(s);

            s = new Rice("Rice 5", Resource.Drawable.basmati_longrice);
            rice.Add(s);

            s = new Rice("Rice 6", Resource.Drawable.basmati_longrice);
            rice.Add(s);

            s = new Rice("Rice 7", Resource.Drawable.basmati_longrice);
            rice.Add(s);

            s = new Rice("Rice 8", Resource.Drawable.basmati_longrice);
            rice.Add(s);

            return rice;
        }

          
     }
 }
