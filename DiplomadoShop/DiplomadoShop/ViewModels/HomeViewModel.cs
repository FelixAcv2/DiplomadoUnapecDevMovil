using DiplomadoShop.Common;
using DiplomadoShop.Contract.General;
using DiplomadoShop.Extensions;
using DiplomadoShop.Models;
using DiplomadoShop.Services.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiplomadoShop.ViewModels
{
   public class HomeViewModel:ViewModelBase
    {
        ProductOfWeekRepository _productOfWeekRepository;
        private readonly INavigationService _navigationService;
        public ICommand ProductTappedCommand => new Command(OnProductTappedCommand);
        public ICommand AddToCartCommand => new Command<Product>(OnAddToCart);

      
        public HomeViewModel(ProductOfWeekRepository productOfWeekRepository, INavigationService navigationService)
        {
            _productOfWeekRepository = productOfWeekRepository;
            _navigationService = navigationService;
            Title = "Products Of The Week";
            LoadProducts();
        }


        private void OnAddToCart(Product product)
        {

            if (product != null)
            {

                App.Master.DisplayAlert("Anadir a la order ", product.Name, "OK");


            }
        }

        private async void OnProductTappedCommand(object args)
        {
            var _product = args as Product;

          await  _navigationService.NavigateToAsync<ProductDetailViewModel>(_product);
         
        }


        ObservableCollection<Product> _productsOfTheWeek;
        public ObservableCollection<Product> ProductsOfTheWeek
        {
            get
            {
                if (_productsOfTheWeek == null)
                    _productsOfTheWeek = new ObservableCollection<Product>();
                return _productsOfTheWeek;
            }

            set
            {
                _productsOfTheWeek = value;
                RaisePropertyChanged();
            }

        }
        async Task LoadProducts()
        {

            ProductsOfTheWeek = (await _productOfWeekRepository.ProductsAsync()).ToObservableCollection();
        }

    }
}
