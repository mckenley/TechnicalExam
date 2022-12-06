using Prism.Navigation;
using System;
using TechnicalExam.Services;

namespace TechnicalExam.ViewModels
{
    public class UserListPageViewModel : ViewModelBase
    {
        private readonly IUserService _userService;

        public UserListPageViewModel(IUserService userService)
        {
            _userService = userService;
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            try
            {
                var test = await _userService.GetUsers();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
