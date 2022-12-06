using Prism.Navigation;
using System;
using System.Collections.Generic;
using TechnicalExam.Models;
using TechnicalExam.Services;

namespace TechnicalExam.ViewModels
{
    public class UserListPageViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        public List<UserModel> Users { get; set; }

        public UserListPageViewModel(IUserService userService)
        {
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
    }
}
