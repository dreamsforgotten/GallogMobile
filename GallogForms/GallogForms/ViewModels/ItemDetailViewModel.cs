using System;

using GallogForms.Models;

namespace GallogForms.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Entry Item { get; set; }
        public ItemDetailViewModel(Entry item = null)
        {
            Title = item?.API;
            Item = item;
        }
    }
}
