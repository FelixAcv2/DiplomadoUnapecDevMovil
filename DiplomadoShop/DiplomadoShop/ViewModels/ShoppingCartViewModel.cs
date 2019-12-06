using DiplomadoShop.Common;
using DiplomadoShop.Constants;
using DiplomadoShop.Contract.General;
using DiplomadoShop.Extensions;
using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DiplomadoShop.ViewModels
{
   public class ShoppingCartViewModel:ViewModelBase
    {
        ISettingsService _settingsService;
        IDialogService _dialogService;

        public ShoppingCartViewModel(ISettingsService settingsService, IDialogService dialogService)
        {
            _settingsService = settingsService;
            _dialogService = dialogService;
            this.Title = "Shopping";
            // OrderDetailCartItems = new ObservableCollection<OrderDetailTmp>();
        }

        ObservableCollection<OrderDetailTmp> _OrderDetailCartItems;
        public ObservableCollection<OrderDetailTmp> OrderDetailCartItems
        {
            get {
                if (_OrderDetailCartItems == null)
                    _OrderDetailCartItems = new ObservableCollection<OrderDetailTmp>();
                return _OrderDetailCartItems;
            }
            set
            {
                _OrderDetailCartItems = value;
                RecalculateBasket();
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<ShoppingCartItem> _shoppingCartItems;
        public ObservableCollection<ShoppingCartItem> ShoppingCartItems
        {
            get
            {

                if (_shoppingCartItems == null)
                    _shoppingCartItems = new ObservableCollection<ShoppingCartItem>();
                return _shoppingCartItems;
            }
            set
            {
                _shoppingCartItems = value;
                RecalculateBasket();
                RaisePropertyChanged();
            }
        }

        private decimal _orderTotal;
        decimal _grandTotal;
        public decimal GrandTotal
        {
            get => _grandTotal;
            set
            {
                _grandTotal = value;
                RaisePropertyChanged();
            }
        }

        decimal _shipping;
        public decimal Shipping
        {
            get => _shipping;
            set
            {
                _shipping = value;
                RaisePropertyChanged();
            }
        }

        decimal _taxes;
        public decimal Taxes
        {
            get => _taxes;
            set
            {
                _taxes = value;
                RaisePropertyChanged();
            }
        }

        private decimal CalculateOrderTotal()
        {
            decimal total = 0;

            //foreach (var shoppingCartItem in ShoppingCartItems)
            //{
            //    total += shoppingCartItem.Quantity * shoppingCartItem.Product.Price;
            //}


            foreach (var orderdetailCartItem in OrderDetailCartItems)
            {
                total += orderdetailCartItem.Quantity * orderdetailCartItem.Product.Price;
            }

            return total;
        }
        private void OnOrderPlaced()
        {
           
            OrderDetailCartItems.Clear();
        }

        private void RecalculateBasket()
        {
            _orderTotal = CalculateOrderTotal();
            Taxes = _orderTotal * (decimal)0.18;
            Shipping = _orderTotal * (decimal)0.3;
            GrandTotal = _orderTotal + _shipping + _taxes;


        }
        public void InitializeMessenger()
        {

            MessagingCenter.Subscribe<ProductDetailViewModel, ShoppingCartItem>(this, MessagingConstants.AddProductToBasket,
                (productDetailViewModel, shoppingCartItem) => OnAddProductToBasketReceived(shoppingCartItem));

            MessagingCenter.Subscribe<HomeViewModel, Product>(this, MessagingConstants.AddProductToBasket,
                           (homeViewModel, product) => OnAddProductToBasketReceived(product));

            //MessagingCenter.Subscribe<CheckoutViewModel>(this, "OrderPlaced", model => OnOrderPlaced());
        }

        private async void OnAddProductToBasketReceived(Product product)
        {
            var _shoppingCartItem = new ShoppingCartItem() { Product = product, ProductId = product.ProductId, Quantity = 1 };
            //await _shoppingCartService.AddShoppingCartItem(shoppingCartItem, "FAcevedo"); //_settingsService.UserIdSetting
            //ShoppingCartItems.Add(shoppingCartItem);


            //var _orderDetail = new OrderDetailTmp { Product = product, ProductId = product.ProductId, Quantity = 1 };
            //OrderDetailCartItems.Add(_orderDetail);
            

            await AddCartItem(_shoppingCartItem);
            RecalculateBasket();
        }

        private async void OnAddProductToBasketReceived(ShoppingCartItem shoppingCartItem) {

            await AddCartItem(shoppingCartItem);
            RecalculateBasket();

        }

        private async Task AddCartItem(ShoppingCartItem cartItem)
        {

            await Task.Run(() => {

                if (cartItem != null)
                {
                    App.CartItems.Add(cartItem);
                }

            });
        }

        private async Task<List<ShoppingCartItem>> GetCartItems()
        {

            return await Task.Run<List<ShoppingCartItem>>(() => {
                return App.CartItems;
            });
        }

        public async override Task InitializeAsync(object data)
        {
            ShoppingCartItems = (await GetCartItems()).ToObservableCollection();
        }
    }
}
