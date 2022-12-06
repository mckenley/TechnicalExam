using Prism.Mvvm;
using Prism.Navigation;

namespace TechnicalExam.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
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
