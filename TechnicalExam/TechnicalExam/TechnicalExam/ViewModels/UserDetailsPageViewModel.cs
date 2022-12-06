using Prism.Navigation;
using TechnicalExam.Models;

namespace TechnicalExam.ViewModels
{
    public class UserDetailsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public UserModel CurrentUser { get; set; }
        public UserDetailsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("SelectedUser"))
            {
                CurrentUser = parameters["SelectedUser"] as UserModel;              
            }
        }
    }
}
