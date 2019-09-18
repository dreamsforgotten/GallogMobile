﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GallogForms.Models;
using Gallog.Api.Models;

namespace GallogForms.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CommoditiesPage : ContentPage
    {
        public CommoditiesPage()
        {
            InitializeComponent();
            BindingContext = new CommoditiesList();
        }
    }
}