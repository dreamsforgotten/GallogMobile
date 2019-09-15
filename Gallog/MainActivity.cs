using System.Collections.Generic;
using System.Threading.Tasks;
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
using Android.Widget;
using Android.Graphics;
using Refit;
using Gallog.Interface;
using EDMTDialog;
using Gallog.Models;
using System;
using Plugin.CurrentActivity;

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
        private MissionsFragment mFragment6;
        private TradeportsFragment mFragment7;
        private CommadatiesFragment mFragment8;
        private MiningFragment mFragment9;
        private MyOrgFragment mFragment10;
        private SearchFragment mFragment11;
        private ShipsFragment mFragment12;
        private ComponentsFragment mFragment13;
        private StoresFragment mFragment14;
        private Stack<SupportFragment> mStackFragment;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
          //  Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            ActionBar.Hide();     

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
            mFragment6 = new MissionsFragment();
            mFragment7 = new TradeportsFragment();
            mFragment8 = new CommadatiesFragment();
            mFragment9 = new MiningFragment();
            mFragment10 = new MyOrgFragment();
            mFragment11 = new SearchFragment();
            mFragment12 = new ShipsFragment();
            mFragment13 = new ComponentsFragment();
            mFragment14 = new StoresFragment();
            mStackFragment = new Stack<SupportFragment>(); 

            

            var trans = SupportFragmentManager.BeginTransaction();

            trans.Add(Resource.Id.fragmentContainer, mFragment14, "Stores Fragment");
            trans.Hide(mFragment14);

            trans.Add(Resource.Id.fragmentContainer, mFragment13, "Components Fragment");
            trans.Hide(mFragment13);

            trans.Add(Resource.Id.fragmentContainer, mFragment12, "Ships Fragment");
            trans.Hide(mFragment12);

            trans.Add(Resource.Id.fragmentContainer, mFragment11, "Search Fragment");
            trans.Hide(mFragment11);

            trans.Add(Resource.Id.fragmentContainer, mFragment10, "MyOrg Fragment");
            trans.Hide(mFragment10);

            trans.Add(Resource.Id.fragmentContainer, mFragment9, "Mining Fragment");
            trans.Hide(mFragment9);

            trans.Add(Resource.Id.fragmentContainer, mFragment8, "Commadaties Fragment");
            trans.Hide(mFragment8);

            trans.Add(Resource.Id.fragmentContainer, mFragment7, "Tradeports Fragment");
            trans.Hide(mFragment7);

            trans.Add(Resource.Id.fragmentContainer, mFragment6, "Missions Fragment");
            trans.Hide(mFragment6);

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
            //    return true;
            }
            else if (id == Resource.Id.nav_hangar)
            {
                ; ShowFragment(mFragment2);
             //   return true;
            }
     //       else if (id == Resource.Id.nav_org)
     //       {
     //           return true;
     //       }
            else if (id == Resource.Id.nav_myorg)
            {
                ShowFragment(mFragment3);
             //   return true;
            }
            else if (id == Resource.Id.nav_missions)
            {
                ShowFragment(mFragment6);
             //   return true;
            }
        //    else if (id == Resource.Id.nav_trade)
        //    {
        //        return true;
        //    }
            else if (id == Resource.Id.nav_trading)
            {
                ShowFragment(mFragment4);
            //    return true;
            }
            else if (id == Resource.Id.nav_tradeports)
            {
                ShowFragment(mFragment7);
             //   return true;
            }
            else if (id == Resource.Id.nav_commadaties)
            {
                ShowFragment(mFragment8);
            //    return true;
            }
            else if (id == Resource.Id.nav_mining)
            {
                ShowFragment(mFragment9);
             //   return true;
            }
        //    else if (id == Resource.Id.nav_databank)
        //    {
        //        ShowFragment(mFragment5);
            //    return true;
        //    }
            else if (id == Resource.Id.nav_search)
            {
                ShowFragment(mFragment11);
            //    return true;
            }
            else if (id == Resource.Id.nav_ships)
            {
                ShowFragment(mFragment12);
            //    return true;
            }
            else if (id == Resource.Id.nav_components)
            {
                ShowFragment(mFragment13);
             //   return true;
            }
            else if (id == Resource.Id.nav_stores)
            {
                ShowFragment(mFragment14);
             //   return true;
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

