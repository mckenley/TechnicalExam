using Acr.UserDialogs;
using Prism.Mvvm;
using Prism.Navigation;
using System.ComponentModel;
using Xamarin.Essentials;

namespace TechnicalExam.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IInitialize, INotifyPropertyChanged
    {
        public bool IsBusy { get; set; }
        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public bool IsConnectedToInternet()
        {
            IsBusy = true;
            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                UserDialogs.Instance.Alert("Please check your internet connection and try again.", okText: "OK");
                return false;
            }
            else
                return true;
        }
    }
}
