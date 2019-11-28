using DiplomadoShop.Contract.Data;
using DiplomadoShop.Models;
using DiplomadoShop.Services.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DiplomadoShop.Common;
using DiplomadoShop.Contract.General;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiplomadoShop.ViewModels
{
   public class MainPageViewModel: ViewModelBase
    {
        public ObservableCollection<NavigationMenuItems> MenuItems { get; set; }

        INavigationMenuItemRepository _navigationMenuItemRepository;
        private readonly INavigationService _navigationService;
        public ICommand MenuTappedCommand => new Command<NavigationMenuItems>(OnMenuTapped);

        private void OnMenuTapped(NavigationMenuItems menu)
        {
            if (menu!=null) {

                _navigationService.NavigateToAsync(menu.ViewType);   
            }
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
           _navigationMenuItemRepository = new NavigationMenuItemRepository();
            MenuItems = new ObservableCollection<NavigationMenuItems>();
            LoadData();
        }
        public  void LoadData()
        {
            var _results = _navigationMenuItemRepository.LoadMenu();

            if (_results != null && _results.Any())
            {


                foreach (var menu in _results)
                {
                    MenuItems.Add(menu);
                }
            }
        }

        NavigationMenuItems _selectedMenuItem;

       

        public NavigationMenuItems SelectedMenuItem {
            get {
                if (_selectedMenuItem == null)
                    _selectedMenuItem = new NavigationMenuItems();
                return _selectedMenuItem;
            }

            set {
               
                if (value != null) {
                   // App.Master.IsPresented = false;
                    _selectedMenuItem = value;
                   
                    RaisePropertyChanged();

                  
                }

              
              
            }

       
    }



    }
}
