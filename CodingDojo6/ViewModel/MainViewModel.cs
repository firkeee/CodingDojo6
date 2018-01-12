using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System;
using System.Timers;
using System.Threading;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private Messenger messenger = SimpleIoc.Default.GetInstance<Messenger>();

        Thread newThread;

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; RaisePropertyChanged(); }
        }

        private BitmapImage messageImage;

        public BitmapImage MessageImage
        {
            get { return messageImage; }
            set { messageImage = value; RaisePropertyChanged(); }
        }



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
            Message = "";

            SwitchToMyToysBtnClicked = new RelayCommand(() =>
            {
                CurrentViewModel = SimpleIoc.Default.GetInstance<MyToysVm>();
            });

            SwitchToOverviewBtnClicked = new RelayCommand(() =>
            {
                CurrentViewModel = SimpleIoc.Default.GetInstance<OverviewVm>();
            });

            CurrentViewModel = SimpleIoc.Default.GetInstance<OverviewVm>();

            messenger.Register<PropertyChangedMessage<ItemVm>>(this, "Write", DisplayMessageThread);
        }

        private void DisplayMessageThread(PropertyChangedMessage<ItemVm> obj)
        {
            newThread = new Thread(DisplayMessage);
            newThread.Start();
        }
    

        private void DisplayMessage()
        {
            Message = "New Toy added!";
            RaisePropertyChanged("Message");

            App.Current.Dispatcher.Invoke(() =>
            {
                MessageImage = new BitmapImage(new Uri("Images/State_Info.png", UriKind.Relative));
                RaisePropertyChanged("MessageImage");
            });

            Thread.Sleep(3000);

            Message = "";
            RaisePropertyChanged("Message");

            App.Current.Dispatcher.Invoke(() =>
            {
                MessageImage = null;
                RaisePropertyChanged("MessageImage");
            });
        }
    }
}