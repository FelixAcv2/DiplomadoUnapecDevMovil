using DiplomadoShop.Common;
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
   public class CustomerLocalViewModel:ViewModelBase
    {
        private readonly CustomerLocalRepository _customerLocalRepository;
        private readonly INavigationService _navigationService;

        public ICommand AddCustomerCommand => new Command(OnExecuteAddCustomer);
        public ICommand EditCustomerCommand => new Command<Customer>(OnExecuteEditCustomer);
        public ICommand DetailCustomerCommand => new Command(OnExecuteDetailCustomer);
        public ICommand RemoverCustomerCommand => new Command(OnExecuteRemoverCustomer);
        public ICommand RefreshCommand => new Command(OnExecuteRefresh);

        public ICommand FilterCommand => new Command(OnFilterCustomers);

       
        public ICommand CustomerTappedCommand => new Command(OnExecuteCustomerTapper);

       

        private async void OnExecuteDetailCustomer(object args)
        {
            var _curtomerSelected = args as Customer;

            await _navigationService.NavigateToAsync<CustormeDetailViewModel>(_curtomerSelected);

        }

        public CustomerLocalViewModel(CustomerLocalRepository customerLocalRepository, INavigationService navigationService)
        {
            _customerLocalRepository = customerLocalRepository;
            _navigationService = navigationService;

            Title = "Local Customer";
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

        private async void OnExecuteRefresh(object obj)
        {
            await LoadData();
        }

        private void OnExecuteRemoverCustomer(object obj)
        {

        }
        private async void OnExecuteEditCustomer(Customer args)
        {
            var _curtomerSelected = args as Customer;

            await _navigationService.NavigateToAsync<CustomerAddViewModel>(_curtomerSelected);
        }

        private async void OnExecuteCustomerTapper(object args)
        {
            var _curtomerSelected = args as Customer;

            await   _navigationService.NavigateToAsync<CustormeDetailViewModel>(_curtomerSelected);


        }

   


        private async void OnExecuteAddCustomer(object obj)
        {
            await _navigationService.NavigateToAsync<CustomerAddViewModel>();
        }

        string _filterName;
        public string FilterName { get => _filterName; set { _filterName = value; RaisePropertyChanged(); } }

        ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get
            {
                if (_customers == null)
                    _customers = new ObservableCollection<Customer>();
                return _customers;
            }

            set
            {
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


        public async override Task InitializeAsync(object data)
        {
           await LoadData();
        }

        Task LoadData() {
            IsRefresh = true;
           var _task= Task.Run(()=> {

               CustomersUnfiltered = (_customerLocalRepository.GetCustomers()).ToObservableCollection();
               Customers = CustomersUnfiltered;



             });
            IsRefresh = false;
            return  _task;

        }
    }
}
