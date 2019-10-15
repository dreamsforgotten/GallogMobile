using GallogForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GallogForms.Interfaces
{
    public class ItemSelectedCommandBehavior : Behavior<ListView>

    {

        public static readonly BindableProperty CommandProperty =
                BindableProperty.Create(
                    propertyName: "Command",
                    returnType: typeof(ICommand),
                    declaringType: typeof
                   (ItemSelectedCommandBehavior));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemSelected += BindableOnItemSelected;
            bindable.BindingContextChanged += BindableOnBindingContextChanged;
        }

        private void BindableOnBindingContextChanged(object sender, EventArgs eventArgs)
        {
            var lv = sender as ListView;
            BindingContext = lv?.BindingContext;
        }

        private void BindableOnItemSelected(object sender,
            SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            Command.Execute(null);
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= BindableOnItemSelected;
            bindable.BindingContextChanged -= BindableOnBindingContextChanged;
        }

        private void ListView_BindingContextChanged(object sender, EventArgs eventArgs)
        {
            var listView = sender as ListView;
            BindingContext = listView?.BindingContext;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Command.Execute(null);
        }
    }
}
