using DiplomadoShop.Common;
using DiplomadoShop.Contract.Data;
using DiplomadoShop.Extensions;
using DiplomadoShop.Models;
using DiplomadoShop.Services.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DiplomadoShop.Contract.DataService;
using System.Windows.Input;
using Xamarin.Forms;
using DiplomadoShop.Contract.General;

namespace DiplomadoShop.ViewModels
{
   public class ProductViewModel:ViewModelBase
    {

        IProductDataService _productDataService;
        INavigationService _navigationService;
        public ICommand RefreshCommand => new Command(OnExecuteRefresh);

        public ICommand FilterCommand => new Command(OnFilterProducts);

        public ICommand ProductTappedCommand => new Command(OnProductTappedCommand);

        private async void OnProductTappedCommand(object args)
        {
            var _product = args as Product;

            await _navigationService.NavigateToAsync<ProductDetailViewModel>(_product);

        }

        public ProductViewModel(IProductDataService productDataService, INavigationService navigationService)
        {

            _navigationService = navigationService;
            _productDataService = productDataService;
            Title = "Products";

           
        }

        private void OnFilterProducts(object obj)
        {
            // var _customer = args != null ? args as Customer : null;
            if (string.IsNullOrWhiteSpace(FilterName))
            {
                Products = ProductsUnfiltered;
            }
            else
            {

                ProductsFiltered = new ObservableCollection<Product>(ProductsUnfiltered.Where(x => x.Name.Contains(FilterName.ToUpper())));
                Products = ProductsFiltered;
            }
        }

        private async void OnExecuteRefresh(object obj)
        {
            await LoadData();
        }



        string _filterName;
        public string FilterName { get => _filterName; set { _filterName = value; RaisePropertyChanged(); } }


        ObservableCollection<Product> _productsUnfiltered;
        public ObservableCollection<Product> ProductsUnfiltered
        {
            get => _productsUnfiltered;
            set
            {
                _productsUnfiltered = value;
                RaisePropertyChanged();
            }
        }

        ObservableCollection<Product> _productsfiltered;
        public ObservableCollection<Product> ProductsFiltered
        {
            get => _productsfiltered;
            set
            {
                _productsfiltered = value;
                RaisePropertyChanged();
            }
        }

        ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products {
            get {
                if (_products == null)
                    _products = new ObservableCollection<Product>();
                return _products;
            }

            set {
                _products = value;
                RaisePropertyChanged();
            }
        
        }


        async Task LoadData()
        {
            IsRefresh = true;
           
            await Task.Run(async () => {

                ProductsUnfiltered = (await _productDataService.ProductsAsync()).ToObservableCollection();
                Products = ProductsUnfiltered;



            });
            IsRefresh = false;
          

        }
        public async override Task InitializeAsync(object data)
        {
            //IsBusy = true;
            //Products = (await _productDataService.ProductsAsync()).ToObservableCollection();
            //IsBusy = false;

            await LoadData();
        }



    }
}
