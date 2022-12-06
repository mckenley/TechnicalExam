using Prism;
using Prism.Ioc;
using Prism.Unity;
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
            NavigationService.NavigateAsync(nameof(ViewNames.MainPage));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
