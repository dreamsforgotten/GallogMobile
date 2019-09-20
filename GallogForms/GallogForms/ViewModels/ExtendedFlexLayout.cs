﻿using System;
using System.Collections.Generic;
using System.Text;
    
using System.Collections;
using Xamarin.Forms;

    namespace GallogForms.ViewModels
    {
        public class ExtendedFlexLayout : FlexLayout
        {
            public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(ExtendedFlexLayout), propertyChanged: OnItemsSourceChanged);
            public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(ExtendedFlexLayout));

            public IEnumerable ItemsSource
            {
                get { return (IEnumerable)GetValue(ItemsSourceProperty); }
                set { SetValue(ItemsSourceProperty, value); }
            }

            public DataTemplate ItemTemplate
            {
                get { return (DataTemplate)GetValue(ItemTemplateProperty); }
                set { SetValue(ItemTemplateProperty, value); }
            }

            static void OnItemsSourceChanged(BindableObject bindable, object oldVal, object newVal)
            {
                IEnumerable newValue = newVal as IEnumerable;
                var layout = (ExtendedFlexLayout)bindable;

                layout.Children.Clear();
                if (newValue != null)
                {
                    foreach (var item in newValue)
                    {
                        layout.Children.Add(layout.CreateChildView(item));
                    }
                }
            }

            View CreateChildView(object item)
            {
                ItemTemplate.SetValue(BindableObject.BindingContextProperty, item);
                return (View)ItemTemplate.CreateContent();
            }
        }
    }