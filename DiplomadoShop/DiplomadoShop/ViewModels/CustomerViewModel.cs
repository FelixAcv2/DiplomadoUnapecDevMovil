using DiplomadoShop.Common;
using DiplomadoShop.Contract.DataService;
using DiplomadoShop.Contract.General;
using DiplomadoShop.Extensions;
using DiplomadoShop.Models;
using DiplomadoShop.Services.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public ICommand RefreshCommand => new Command(OnExecuteRefresh);

        public ICommand FilterCommand => new Command(OnFilterCustomers);
        public CustomerViewModel( INavigationService navigationService, 
                                  LocalDatabaseManager localDatabaseManager,
                                  ICustomerDataService customerDataService)
        {
            this.Title = "Customers";
            _navigationService = navigationService; 
            _customerDataService = customerDataService;
            _localDatabaseManager = localDatabaseManager;
            //_localDatabaseManager
        }

        private void OnFilterCustomers(object obj)
        {
            // var _customer = args != null ? args as Customer : null;
            if (string.IsNullOrWhiteSpace(FilterName))
            {
                Customers = CustomersUnfiltered;
            }
            else
            {

                CustomersFiltered = new ObservableCollection<Customer>(CustomersUnfiltered.Where(x => x.Name.Contains(FilterName.ToUpper())));
                Customers = CustomersFiltered;
            }
        }
        private async void OnAddCustomer(object obj)
        {
            await _navigationService.NavigateToAsync<CustomerAddViewModel>();
        }

        private async void OnExecuteRefresh(object obj)
        {
            await LoadData();
        }

        string _filterName;
        public string FilterName { get => _filterName; set { _filterName = value; RaisePropertyChanged(); } }

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

        ObservableCollection<Customer> _customersUnfiltered;
        public ObservableCollection<Customer> CustomersUnfiltered
        {
            get => _customersUnfiltered;
            set
            {
                _customersUnfiltered = value;
                RaisePropertyChanged();
            }
        }

        ObservableCollection<Customer> _customersfiltered;
        public ObservableCollection<Customer> CustomersFiltered
        {
            get => _customersfiltered;
            set
            {
                _customersfiltered = value;
                RaisePropertyChanged();
            }
        }



      async  Task LoadData()
        {
            IsRefresh = true;
            IsBusy = true;
            await Task.Run(async() => {

                CustomersUnfiltered = (await _customerDataService.CustomersAsync()).ToObservableCollection();
                Customers = CustomersUnfiltered;



            });
            IsRefresh = false;
            IsBusy = false;

        }
        public async override Task InitializeAsync(object data)
        {
            //IsBusy = true;
            //Customers = (await _customerDataService.CustomersAsync()).ToObservableCollection();
            //IsBusy = false;
            await  LoadData();

        }

    }
}
