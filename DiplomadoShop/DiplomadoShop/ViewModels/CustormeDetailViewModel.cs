using DiplomadoShop.Common;
using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiplomadoShop.ViewModels
{
   public class CustormeDetailViewModel:ViewModelBase
    {
        public CustormeDetailViewModel()
        {

        }

        Customer _currentCustomer;
        public Customer CurrentCustomer {

            get {
                if (_currentCustomer == null)
                    _currentCustomer = new Customer();
                return _currentCustomer;

            }

            set {
                _currentCustomer = value;
                RaisePropertyChanged();
            }
        
        }


        public async override Task InitializeAsync(object data)
        {
            CurrentCustomer = data as Customer;
        }

    }
}
