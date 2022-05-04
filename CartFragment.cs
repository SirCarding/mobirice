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
    [Activity(Label = "CartFragment")]
    public class CartFragment : AndroidX.Fragment.App.Fragment
    {
        View view;

        public override View OnCreateView(LayoutInflater inflater,ViewGroup container,Bundle savedInstanceState)
        {
           view = inflater.Inflate(Resource.Layout.cart_layout, container, false);
            return view;

        }
    }
}