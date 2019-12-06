using DiplomadoShop.Bootstrap;
using DiplomadoShop.Contract.General;
using DiplomadoShop.Models;
using DiplomadoShop.ViewModels;
using DiplomadoShop.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiplomadoShop
{
    public partial class App : Application
    {
        public static List<ShoppingCartItem> CartItems { get; set; }
        public static NavigationPage Navigator { get; internal set; }
        public static MasterDetailPageView Master { get; internal set; }
        public App()
        {
            InitializeComponent();
            CartItems = new List<ShoppingCartItem>();
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
            //Aqui Code para initialize Shopping
            var _shoppingCartViewModel = AppContainer.Resolve<ShoppingCartViewModel>();
            _shoppingCartViewModel.InitializeMessenger();
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
