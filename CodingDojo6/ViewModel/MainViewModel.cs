using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System;

namespace CodingDojo6.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        private Messenger messenger = SimpleIoc.Default.GetInstance<Messenger>();

        public RelayCommand SwitchToOverviewBtnClicked { get; set; }
        public RelayCommand SwitchToMyToysBtnClicked { get; set; }
        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set {
                currentViewModel = value;
                RaisePropertyChanged();
            }
        }


        public MainViewModel()
        {
            
            SwitchToMyToysBtnClicked = new RelayCommand(()=>
            {
                CurrentViewModel = SimpleIoc.Default.GetInstance<MyToysVm>();
            });

            SwitchToOverviewBtnClicked = new RelayCommand(() =>
            {
                CurrentViewModel = SimpleIoc.Default.GetInstance<OverviewVm>();
            });

            CurrentViewModel = SimpleIoc.Default.GetInstance<OverviewVm>();

            messenger.Register<PropertyChangedMessage<ItemVm>>(this, "Write", DisplayMessage);
        }

        private void DisplayMessage(PropertyChangedMessage<ItemVm> obj)
        {
            
        }
    }
}