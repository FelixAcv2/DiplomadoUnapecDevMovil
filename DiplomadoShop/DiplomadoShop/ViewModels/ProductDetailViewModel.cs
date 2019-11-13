using DiplomadoShop.Common;
using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiplomadoShop.ViewModels
{
   public class ProductDetailViewModel:ViewModelBase
    {
        public ProductDetailViewModel()
        {
            Title="Product Detail";
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


        public async override Task InitializeAsync(object data)
        {
            var _product = data as Product;
            CurrentProduct = _product;
        }

    }
}
