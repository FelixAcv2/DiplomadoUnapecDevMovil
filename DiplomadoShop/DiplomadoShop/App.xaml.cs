using DiplomadoShop.Bootstrap;
using DiplomadoShop.Contract.General;
using DiplomadoShop.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiplomadoShop
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        public static MasterDetailPageView Master { get; internal set; }
        public App()
        {
            InitializeComponent();

            InitializeApp();
            InitializeNavigation();
          //  MainPage = new MasterDetailPageView();
        }

        private async void InitializeNavigation()
        {
            var _navigationService = AppContainer.Resolve<INavigationService>();
            await _navigationService.InitializeAsync();
        }
        private void InitializeApp()
        {
            AppContainer.ContainerConfigure();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
