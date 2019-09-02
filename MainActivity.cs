using System;
using System.Collections.Generic;
using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.App;
using Android.Views;
using Gallog.Fragments;

namespace Gallog
{
  
    [Activity(Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {

        private SupportFragment mCurrentFragment;
        private HomeFragment mFragment1;
        private HangarFragment mFragment2;
        private OrgFragment mFragment3;
        private TradeFragment mFragment4;
        private DatabankFragment mFragment5;
        private Stack<SupportFragment> mStackFragment;
        
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            mFragment1 = new HomeFragment();
            mFragment2 = new HangarFragment();
            mFragment3 = new OrgFragment();
            mFragment4 = new TradeFragment();
            mFragment5 = new DatabankFragment();
            mStackFragment = new Stack<SupportFragment>();

            var trans = SupportFragmentManager.BeginTransaction();

            trans.Add(Resource.Id.fragmentContainer, mFragment5, "Databank Fragment");
            trans.Hide(mFragment5);

            trans.Add(Resource.Id.fragmentContainer, mFragment4, "Trade Fragment");
            trans.Hide(mFragment4);

            trans.Add(Resource.Id.fragmentContainer, mFragment3, "Org Fragment");
            trans.Hide(mFragment3);

            trans.Add(Resource.Id.fragmentContainer, mFragment2, "Hangar Fragment");
            trans.Hide(mFragment2);

            trans.Add(Resource.Id.fragmentContainer, mFragment1, "Home Fragment");
            trans.Commit();

            mCurrentFragment = mFragment1;

        }


        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }

            if (SupportFragmentManager.BackStackEntryCount > 0)
            {
                SupportFragmentManager.PopBackStack();
                mCurrentFragment = mStackFragment.Pop();
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void ShowFragment(SupportFragment fragment)
        {
            var trans = SupportFragmentManager.BeginTransaction();

            trans.Hide(mCurrentFragment);
            trans.Show(fragment);
            trans.AddToBackStack(null);
            trans.Commit();

            mStackFragment.Push(mCurrentFragment);
            mCurrentFragment = fragment;

        }


        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_home)
            {
                ShowFragment(mFragment1);
                return true;
            }
            else if (id == Resource.Id.nav_hangar)
            {
                ; ShowFragment(mFragment2);
                return true;
            }
            else if (id == Resource.Id.nav_myorg)
            {
                ShowFragment(mFragment3);
                return true;
            }
            else if (id == Resource.Id.nav_trade)
            {
                ShowFragment(mFragment4);
                return true;
            }
            else if (id == Resource.Id.nav_databank)
            {
                ShowFragment(mFragment5);
                return true;
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

