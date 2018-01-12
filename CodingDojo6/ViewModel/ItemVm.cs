using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class ItemVm : ViewModelBase
    {
        public ObservableCollection<ItemVm> Items;

        public string Description { get; set; }
        public string AgeRec { get; set; }
        public BitmapImage Image { get; set; }
        public ItemVm(string description, string ageRec, BitmapImage image)
        {
            Description = description;
            AgeRec = ageRec;
            Image = image;
        }

        public void AddItem(ItemVm item)
        {
            if (Items == null)
                Items = new ObservableCollection<ItemVm>();

            Items.Add(item);
        }

    }
}
