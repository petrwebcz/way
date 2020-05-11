using System;

using WhereAreYou.Xamarin.Forms.Models;

namespace WhereAreYou.Xamarin.Forms.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
