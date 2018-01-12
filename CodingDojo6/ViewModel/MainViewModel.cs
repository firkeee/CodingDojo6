using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using System.Collections.ObjectModel;

namespace CodingDojo6.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand SwitchToOverviewBtnClicked;
        public RelayCommand SwitchToMyToysBtnClicked;
        public ObservableCollection<ItemVm> MainItems;
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
            MainItems = new ObservableCollection<ItemVm>();
            SwitchToMyToysBtnClicked = new RelayCommand(()=>
            {
                CurrentViewModel = SimpleIoc.Default.GetInstance<MyToysVm>();
            });

            SwitchToOverviewBtnClicked = new RelayCommand(() =>
            {
                CurrentViewModel = SimpleIoc.Default.GetInstance<OverviewVm>();
            });

            CurrentViewModel = SimpleIoc.Default.GetInstance<OverviewVm>();

        }
    }
}