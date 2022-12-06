using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
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
            try
            {
                if (!IsConnectedToInternet())
                {
                    return;
                }

                Users = await _userService.GetUsers();
            }
            catch (Exception ex)
            {
                
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
                { "SelectedUser", user },
            };

            await _navigationService.NavigateAsync(nameof(ViewNames.UserDetailsPage), parameters);
        }
    }
}
