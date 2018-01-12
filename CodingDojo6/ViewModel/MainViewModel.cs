using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using System.Collections.ObjectModel;

namespace CodingDojo6.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
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

        }
    }
}