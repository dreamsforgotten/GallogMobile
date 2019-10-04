﻿using Gallog.Api.Models;
using GallogForms.Interfaces;
using GallogForms.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GallogForms.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ShipsPage : ContentPage
    {

        public ShipsPage()
        {
            InitializeComponent();
            BindingContext = new ShipsViewModel();
        }

        void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as ShipsViewModel;
            ShipsView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                ShipsView.ItemsSource = _container.Items;
            else
                ShipsView.ItemsSource = _container.Items.Where(i => i.name.ToLower().Contains(e.NewTextValue));

            ShipsView.EndRefresh();
        }

        //protected  void OnAppearing()
        //{
        //    base.OnAppearing();

        //    DependencyService.Get<ILodingPageService>()
        //         .InitLoadingPage(new LoadingIndicatorPage1());
        //    DependencyService.Get<ILodingPageService>().ShowLoadingPage();

        //    Device.StartTimer(TimeSpan.FromSeconds(3), () =>
        //    {
        //        DependencyService.Get<ILodingPageService>().HideLoadingPage();

        //        return false;
        //    });
        //}
    }
}