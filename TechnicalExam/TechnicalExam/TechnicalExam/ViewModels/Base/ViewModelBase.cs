using Prism.Mvvm;
using Prism.Navigation;

namespace TechnicalExam.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IInitialize
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
    }
}
