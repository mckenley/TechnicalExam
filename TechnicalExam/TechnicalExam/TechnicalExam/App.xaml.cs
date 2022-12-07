using Prism;
using Prism.Ioc;
using Prism.Unity;
using TechnicalExam.Services;
using TechnicalExam.ViewModels;
using TechnicalExam.Views;

namespace TechnicalExam
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync($"{nameof(ViewNames.NavPage)}/{nameof(ViewNames.UserListPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavPage>();
            containerRegistry.RegisterForNavigation<UserListPage, UserListPageViewModel>();
            containerRegistry.RegisterForNavigation<UserDetailsPage, UserDetailsPageViewModel>();

            containerRegistry.RegisterSingleton<IUserService, UserService>();
        }
    }
}
