using GallogForms.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace GallogForms.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TradingPage : ContentPage
    {
        public TradingPage()
        {
            InitializeComponent();
            BindingContext = new TradingViewModel();
        }
        //void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var _container = BindingContext as TradingViewModel;

        //    if (string.IsNullOrWhiteSpace(e.NewTextValue))
        //       TradingView.ItemsSource = _container.Items;
        //  else
        //  TradingView.ItemsSource = _container.Items.Where(i => i.name.ToLower().Contains(e.NewTextValue));
        
    }
}                  
