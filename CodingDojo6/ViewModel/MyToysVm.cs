using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo6.ViewModel
{
    public class MyToysVm : ViewModelBase
    {
        private Messenger messenger = SimpleIoc.Default.GetInstance<Messenger>();

        public ObservableCollection<ItemVm> Toys { get; set; }

        public MyToysVm()
        {
            Toys = new ObservableCollection<ItemVm>();
            messenger.Register<PropertyChangedMessage<ItemVm>>(this, "Write", update);
        }

        private void update(PropertyChangedMessage<ItemVm> obj)
        {
            Toys.Add(obj.NewValue);
        }
    }
}
