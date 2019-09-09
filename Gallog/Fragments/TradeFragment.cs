using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
using Newtonsoft.Json;
using Plugin.CurrentActivity;

namespace Gallog.Fragments
{


    public class TradeFragment : Fragment, View.IOnClickListener
    {
        Button mButton;
        ListView mListUser;
        IAPIParser apiParser;
        private AlertDialog _dialog;
        private Context _context;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _context = container.Context;
            View view = inflater.Inflate(Resource.Layout.tradefragment, container, false);
            mButton = view.FindViewById<Button>(Resource.Id.btn_get_data);
            mListUser = view.FindViewById<ListView>(Resource.Id.list_user);
            //apiParser = RestService.For<IAPIParser>("https://xkcd.com/info.0.json");
            mButton.SetOnClickListener(this);
            _dialog = new AlertDialog.Builder(Context).SetMessage("test").Create();

            return view;

        }



        public async void OnClick(View v)
        {
            try
            {
                if (!_dialog.IsShowing)
                    _dialog.Show();

                using (var w = new HttpClient())
                {
                    w.BaseAddress = new Uri("https://api.publicapis.org/");
                    var data = await w.GetStringAsync("entries");
                    
                    var users = JsonConvert.DeserializeObject<ApiList>(data);
                    List<string> user_name = new List<string>();
                    foreach (var user in users.entries)
                        user_name.Add(user.API);
                    var adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, user_name.ToArray());
                    if (_dialog.IsShowing)
                        _dialog.Dismiss();
                    mListUser.Adapter = adapter;
                    
                }
                //List<MyUser> users = await apiParser.GetUsers();
                

                

            }
            catch (Exception ex)
            {
                Toast.MakeText(Context, ex.Message, ToastLength.Long).Show();
            }
        }
    }

}