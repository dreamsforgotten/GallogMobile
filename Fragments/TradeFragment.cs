using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using Gallog.Interface;
using Refit;
using EDMTDialog;
using Gallog.Models;
using Android.App;
using Android.Content;
using Plugin.CurrentActivity;

namespace Gallog.Fragments
{


    public class TradeFragment : Fragment, View.IOnClickListener
    {
        Button mButton;
        ListView mListUser;
        IAPIParser apiParser;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState, )
        {
            View view = inflater.Inflate(Resource.Layout.tradefragment, container, false);
            mButton = view.FindViewById<Button>(Resource.Id.btn_get_data);
            mListUser = view.FindViewById<ListView>(Resource.Id.list_user);
            apiParser = RestService.For<IAPIParser>("https://jsonplaceholder.typicode.com/users");
            mButton.SetOnClickListener(this);

           
            return view;

        }     

        

        public async void OnClick(View v)
        {try
                {
                    Activity ac = new Activity();
                    AlertDialog dialog = new EDMTDialogBuilder.(ac)
                    .SetContext(this)
                    .SetMessage("Please wait...")
                    .Build();

                    if (!dialog.IsShowing)
                        dialog.Show();

                    List<MyUser> users = await apiParser.GetUsers();
                    List<string> user_name = new List<string>();

                    foreach (var user in users)
                        user_name.Add(user.name);
                    var adapter = new ArrayAdapter<string>(this,
                        Android.Resource.Layout.SimpleListItem1, user_name);
                    mListUser.Adapter = adapter;
                    if (dialog.IsShowing)
                        dialog.Dismiss();
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, "" + ex.Message, ToastLength.Long).Show();
                }
            }
    } 

}