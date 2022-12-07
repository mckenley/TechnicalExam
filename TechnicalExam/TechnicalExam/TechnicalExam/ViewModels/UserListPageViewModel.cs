using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TechnicalExam.Constants;
using TechnicalExam.Models;
using TechnicalExam.Services;

namespace TechnicalExam.ViewModels
{
    public class UserListPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserService _userService;
        public List<UserModel> Users { get; set; }
        public ICommand SelectUserCommand => new DelegateCommand<UserModel>(async (user) => await SelectUser(user));

        public UserListPageViewModel(INavigationService navigationService, IUserService userService)
        {
            _navigationService = navigationService;
            _userService = userService;
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            await GetUsers();
        }

        private async Task GetUsers()
        {
            try
            {
                if (!IsConnectedToInternet())
                {
                    UserDialogs.Instance.Alert("Please check your internet connection and try again.", okText: "OK");
                    return;
                }

                List<UserModel> users = await _userService.GetUsers();

                Users = users.GroupBy(u => u.Id)
                             .Select(u => u.FirstOrDefault())
                             .ToList();
            }
            catch
            {
                UserDialogs.Instance.Alert("Something went wrong in getting the users. Please try again.", okText: "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task SelectUser(UserModel user)
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { NavigationKeyConstants.SelectedUser , user },
            };

            await _navigationService.NavigateAsync(nameof(ViewNames.UserDetailsPage), parameters);
        }
    }
}
