using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class OverviewVm : ViewModelBase
    {

        public ObservableCollection<ItemVm> MainItems { get; set; }
        private ItemVm selectedItem;

        public ItemVm SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value;
                RaisePropertyChanged();
            }
        }
        private RelayCommand<ItemVm> buyBtnClicked;

        public RelayCommand<ItemVm> BuyBtnClicked
        {
            get { return buyBtnClicked; }
            set { buyBtnClicked = value; RaisePropertyChanged(); }
        }


        public OverviewVm()
        {
            MainItems = new ObservableCollection<ItemVm>();
            GenerateDemoData();
            BuyBtnClicked = new RelayCommand<ItemVm>((p) =>
            {
                int a = 10;
            }, (p)=> {return false; });

            SelectedItem = MainItems[0];
        }

        private void GenerateDemoData()
        {
            MainItems.Add(new ItemVm("My Lego", new BitmapImage(new Uri("Images/lego1.jpg", UriKind.Relative)), "5-10"));
            MainItems.Add(new ItemVm("My Playmobil", new BitmapImage(new Uri("Images/playmobil1.jpg", UriKind.Relative)), "6+"));
            MainItems[0].AddItem(new ItemVm("Helicopter", new BitmapImage(new Uri("Images/lego1.jpg", UriKind.Relative)), "5-10"));
            MainItems[0].AddItem(new ItemVm("Machine", new BitmapImage(new Uri("Images/lego2.jpg", UriKind.Relative)), "1-3"));
            MainItems[0].AddItem(new ItemVm("New Machine", new BitmapImage(new Uri("Images/lego3.jpg", UriKind.Relative)), "3-7"));
            MainItems[0].AddItem(new ItemVm("Digger", new BitmapImage(new Uri("Images/lego4.jpg", UriKind.Relative)), "10+"));
            MainItems[1].AddItem(new ItemVm("House", new BitmapImage(new Uri("Images/playmobil1.jpg", UriKind.Relative)), "6+"));
            MainItems[1].AddItem(new ItemVm("Package", new BitmapImage(new Uri("Images/playmobil2.jpg", UriKind.Relative)), "2-7"));
            MainItems[1].AddItem(new ItemVm("Warriors", new BitmapImage(new Uri("Images/playmobil3.jpg", UriKind.Relative)), "3-6"));

        }
    }
}
