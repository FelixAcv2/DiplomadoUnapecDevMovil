using DiplomadoShop.Common;
using DiplomadoShop.Models;
using DiplomadoShop.Services.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiplomadoShop.ViewModels
{
  public  class CustomerViewModel:ViewModelBase
    {
       private LocalDatabaseManager _localDatabaseManager;

        public ICommand AddCustomerCommand => new Command(OnAddCustomer);

        private void OnAddCustomer(object obj)
        {
            throw new NotImplementedException();
        }

        public CustomerViewModel(LocalDatabaseManager localDatabaseManager)
        {
            _localDatabaseManager = localDatabaseManager;
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


    }
}
