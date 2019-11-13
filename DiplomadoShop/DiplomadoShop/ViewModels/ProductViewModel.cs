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
namespace DiplomadoShop.ViewModels
{
   public class ProductViewModel:ViewModelBase
    {
        IProductRepository _productRepository;
     
        public ProductViewModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
           // Products = new ObservableCollection<Product>();
            Title = "ProductView";

            LoadProducts();
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
        async Task LoadProducts() {

            Products = (await _productRepository.ProductsAsync()).ToObservableCollection();

            //foreach (var item in _resuslts)
            //{
            //    Products.Add(item);
            //}
        }
    }
}
