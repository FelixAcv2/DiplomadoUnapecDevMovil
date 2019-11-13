using DiplomadoShop.Bootstrap;
using DiplomadoShop.Common;
using DiplomadoShop.Contract.General;
using DiplomadoShop.ViewModels;
using DiplomadoShop.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using System.IO;
using DiplomadoShop.Models;

namespace DiplomadoShop.Services.General
{
    public class NavigationService : INavigationService
    {
        protected Application CurrentApplication => Application.Current;
        public async Task InitializeAsync()
        {
            await NavigateToAsync<MasterDetailPageViewModel>();
        }

        public async Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            await InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public async Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            await InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public async Task NavigateToAsync(Type viewModelType)
        {
            await InternalNavigateToAsync(viewModelType, null);
        }

        public async Task NavigateToAsync(Type viewModelType, object parameter)
        {
            await InternalNavigateToAsync(viewModelType,parameter);
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page _page = CreatePage(viewModelType, parameter);

            if (_page is LoginView)
            {

                CurrentApplication.MainPage = new DiplomadoShopNavigationPage(_page);
            }
            else {

                var _navigationPage = CurrentApplication.MainPage as DiplomadoShopNavigationPage;
                if (_navigationPage != null)
                {

                    await _navigationPage.PushAsync(_page);
                }
                else {
                    CurrentApplication.MainPage = new DiplomadoShopNavigationPage(_page);
                }
            }

            await (_page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        
        }

        private Page CreatePage(Type viewModelType, object parameter) {

            Type _pageType = GetPageTypeForViewModel(viewModelType);

            if (_pageType==null) {
                throw new Exception($"No se puede localizar la page {viewModelType}");
            }

            Page _page = Activator.CreateInstance(_pageType) as Page;
            return _page;


        }

        private Type GetPageTypeForViewModel(Type viewModelType) {

            var _viewName = viewModelType.FullName.Replace("Model",string.Empty);
            var _viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var _viewAssemlyName = string.Format(CultureInfo.InvariantCulture,"{0}, {1}",_viewName,_viewModelAssemblyName);
            var _viewType = Type.GetType(_viewAssemlyName);
            return _viewType;
        
        }

        }
}
