using DiplomadoShop.Common;
using DiplomadoShop.Constants;
using DiplomadoShop.Contract.General;
using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiplomadoShop.ViewModels
{
   public class ProductDetailViewModel:ViewModelBase
    {

        public ICommand AddToCartCommand => new Command<string>(OnAddToCart);

        readonly IDialogService _dialogService;
        public ProductDetailViewModel(IDialogService dialogService)
        {
            Title="Product Detail";

            _dialogService = dialogService;
        }

        Product _currentProduct;

        public Product CurrentProduct
        {

            get
            {
                if (_currentProduct == null)
                    _currentProduct = new Product();
                return _currentProduct;
            }

            set
            {
                _currentProduct = value;
                RaisePropertyChanged();
            }

        }

        private async void OnAddToCart(string quantity)
        {
            int _quantityValue = quantity != null ? int.Parse(quantity) : 1;

            var _shoppingCartItem = new ShoppingCartItem() { Product = CurrentProduct, ProductId = CurrentProduct.ProductId, Quantity = _quantityValue };

            MessagingCenter.Send(this, MessagingConstants.AddProductToBasket, _shoppingCartItem);
            await _dialogService.ShowDialog(CurrentProduct.Name, "Producto agregado", "OK");

        }

        public async override Task InitializeAsync(object data)
        {
            var _product = data as Product;
            CurrentProduct = _product;
        }

    }
}
