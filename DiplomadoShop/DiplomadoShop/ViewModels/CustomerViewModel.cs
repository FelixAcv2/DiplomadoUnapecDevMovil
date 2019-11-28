using DiplomadoShop.Common;
using DiplomadoShop.Contract.DataService;
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
  public  class CustomerViewModel:ViewModelBase
    {
        private LocalDatabaseManager _localDatabaseManager;
        private readonly INavigationService _navigationService;
        private readonly ICustomerDataService _customerDataService;
        public ICommand AddCustomerCommand => new Command(OnAddCustomer);

    
        public CustomerViewModel( INavigationService navigationService, 
                                  LocalDatabaseManager localDatabaseManager,
                                  ICustomerDataService customerDataService)
        {
            _navigationService = navigationService;
            _customerDataService = customerDataService;
            _localDatabaseManager = localDatabaseManager;
            //_localDatabaseManager
        }

        private async void OnAddCustomer(object obj)
        {
            await _navigationService.NavigateToAsync<CustomerAddViewModel>();
        }


        ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers {
            get {
                if (_customers == null)
                    _customers = new ObservableCollection<Customer>();
                return _customers;
            }

            set {
                _customers = value;
                RaisePropertyChanged();
            }
        }


        public async override Task InitializeAsync(object data)
        {
            IsBusy = true;
            Customers = (await _customerDataService.CustomersAsync()).ToObservableCollection();
            IsBusy = false;

        }

    }
}
