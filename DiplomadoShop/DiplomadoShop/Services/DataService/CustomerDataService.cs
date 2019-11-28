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
   public class CustomerDataService: ICustomerDataService
    {
        IApiService _apiService;

        public CustomerDataService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<Customer>> CustomersAsync()
        {
            IEnumerable<Customer> _customers = null;

            try
            {
                var _url = ApiConstants.BaseApiUrl + ApiConstants.CustomerAllEndpoint;

                _customers= await Task.FromResult( await _apiService.GetAsync<IEnumerable<Customer>>(_url));
               
            }
            catch (Exception ex)
            {
                if (ex is ConnectionException)
                {
                   
                    Debug.WriteLine($"Loading data local Faile: {ex.Message}");
                    throw new ConnectionException();
                }

            }
            return _customers;
        }
    }
}
