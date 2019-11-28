using DiplomadoShop.Common;
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
using System.Linq;
namespace DiplomadoShop.ViewModels
{
   public class CustomerAddViewModel:ViewModelBase
    {
     
        private readonly CustomerLocalRepository _customerLocalRepository;
        private readonly INavigationService _navigationService;
        public ICommand AddNewCustomerCommand => new Command(OnExecuteAddNewCustomer);

     

        public CustomerAddViewModel(CustomerLocalRepository customerLocalRepository, INavigationService navigationService)
        {
            _customerLocalRepository = customerLocalRepository;
            _navigationService = navigationService;
            Title = "Add New Customer";
        }

        private async void OnExecuteAddNewCustomer(object obj)
        {
            try
            {
                CurrentCustomer.City = SelectedCity.Name;
                CurrentCustomer.State = SelectedState.Name;

                _customerLocalRepository.SaveCustomer(CurrentCustomer);
               await _navigationService.NavigateBackAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
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

        ObservableCollection<City> _cities;
        public ObservableCollection<City> Cities {

            get {

                if (_cities == null)
                    _cities = new ObservableCollection<City>();
                return _cities;
            
            }

            set {
                _cities = value;
                RaisePropertyChanged();
            
            }
        
        }



        City _selectedCity;

        public City SelectedCity {

            get {
                if (_selectedCity == null)
                    _selectedCity = new City();
                return _selectedCity;
            }
            set { _selectedCity = value;
                RaisePropertyChanged();
            }
        }


        City _selectedState;

        public City SelectedState
        {

            get
            {
                if (_selectedState == null)
                    _selectedState = new City();
                return _selectedState;
            }
            set
            {
                _selectedState = value;
                RaisePropertyChanged();
            }
        }


        public async override Task InitializeAsync(object data)
        {
            CurrentCustomer = data as Customer;
            Cities = _customerLocalRepository.Cities.ToObservableCollection();
            if (CurrentCustomer != null)
            {
                this.Title = "Edit Customer";
                SelectedCity =_customerLocalRepository.Cities.FirstOrDefault(x=>x.Name.Equals(CurrentCustomer.City)) ;
                SelectedState= _customerLocalRepository.Cities.FirstOrDefault(x => x.Name.Equals(CurrentCustomer.State));
            }
           
        }

    }
}
