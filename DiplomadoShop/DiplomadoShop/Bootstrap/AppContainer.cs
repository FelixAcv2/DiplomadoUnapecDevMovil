using CommonServiceLocator;
using DiplomadoShop.Contract.Data;
using DiplomadoShop.Contract.DataService;
using DiplomadoShop.Contract.General;
using DiplomadoShop.Services.Data;
using DiplomadoShop.Services.DataService;
using DiplomadoShop.Services.General;
using DiplomadoShop.ViewModels;
using DiplomadoShop.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.ServiceLocation;

namespace DiplomadoShop.Bootstrap
{
  public static  class AppContainer
    {
        static IUnityContainer _container;

        static AppContainer()
        {

            ContainerConfigure();
        }

        public static void ContainerConfigure()
        {
            _container = new UnityContainer();

            _container.RegisterType<ProductViewModel>();
            _container.RegisterType<HomeViewModel>();
            _container.RegisterType<HomeView>();
            _container.RegisterType<ProductView>();
            _container.RegisterType<CustomerView>();
            _container.RegisterType<MainPageView>();
            _container.RegisterType<MasterDetailPageView>();
           // _container.RegisterType(typeof(MainPageViewModel),typeof(MainPageView));
            _container.RegisterType<MainPageViewModel>();
            
            _container.RegisterType<IProductRepository, ProductRepository>();
            _container.RegisterType<IProductRepository, ProductOfWeekRepository>();
            _container.RegisterType<INavigationService, NavigationService>();

            _container.RegisterType<LocalDatabaseManager>();
            _container.RegisterType<IApiService, ApiService>();
            _container.RegisterType<ICustomerDataService, CustomerDataService>();
            

            var _serviceLocator = new UnityServiceLocator(_container);
            ServiceLocator.SetLocatorProvider(() => _serviceLocator);
        }

        public static object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        public static T Resolve<T>()
        {

            return _container.Resolve<T>();
        }
    }
}
