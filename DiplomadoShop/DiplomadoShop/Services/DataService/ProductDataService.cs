using DiplomadoShop.Constants;
using DiplomadoShop.Contract.DataService;
using DiplomadoShop.Exceptions;
using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DiplomadoShop.Services.DataService
{
    public class ProductDataService : IProductDataService
    {
        IApiService _apiService;

        public ProductDataService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<Product>> ProductsAsync()
        {
            IEnumerable<Product> _products = null;

            try
            {
                var _url = ApiConstants.BaseApiUrl + ApiConstants.ProducAllEndpoint;

                return await _apiService.GetAsync<IEnumerable<Product>>(_url);

            }
            catch (Exception ex)
            {
                if (ex is ConnectionException)
                {

                    Debug.WriteLine($"Loading data local Faile: {ex.Message}");
                    throw new ConnectionException();
                }

            }
            return _products;
        }
    }
}
