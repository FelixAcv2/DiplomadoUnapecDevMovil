using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomadoShop.Services.Data
{
  public  class CustomerLocalRepository
    {
        LocalDatabaseManager _localDatabaseManager;

        public CustomerLocalRepository(LocalDatabaseManager localDatabaseManager)
        {
            _localDatabaseManager = localDatabaseManager;
        }


        public async void SaveCustomer(Customer customer) {


            var _existCustomer = await _localDatabaseManager.FindAsync<Customer>(x => x.CustomerId == customer.CustomerId, false);

            if (_existCustomer != null) {

                _localDatabaseManager.Update<Customer>(customer);
            }else
            _localDatabaseManager.Insert<Customer>(customer);


        }

        public IEnumerable<Customer> GetCustomers() {

            return _localDatabaseManager.GetAll<Customer>();
        }


        public IEnumerable<City> Cities
        {

            get {

                return new List<City> { 
                
                new City{CityId=1,Name="SANTO DOMINGO" },
                new City{CityId=2,Name="SANTIAGO" },
                new City{CityId=3,Name="LA VEGA" },
                };
            
            }

        }

    }
}
