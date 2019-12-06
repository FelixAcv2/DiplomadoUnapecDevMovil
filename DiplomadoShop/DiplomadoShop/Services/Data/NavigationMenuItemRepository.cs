using DiplomadoShop.Contract.Data;
using DiplomadoShop.Models;
using DiplomadoShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomadoShop.Services.Data
{
    public class NavigationMenuItemRepository : INavigationMenuItemRepository
    {
        public List<NavigationMenuItems> LoadMenu()
        {
            
            return new List<NavigationMenuItems> { 
             new NavigationMenuItems{Title="Home",Icon="ic_house.png", ViewType=typeof(HomeViewModel) },
             new NavigationMenuItems{Title = "Product", Icon="ic_product.png", ViewType=typeof(ProductViewModel) },
             new NavigationMenuItems{ Title = "Customer", Icon="ic_customer_services.png", ViewType=typeof(CustomerViewModel)},
             new NavigationMenuItems{Title = "Order", Icon="ic_product.png", ViewType=typeof(ShoppingCartViewModel) },
             new NavigationMenuItems{ Title = "Customer SQLite", Icon="ic_customer_services.png", ViewType=typeof(CustomerLocalViewModel)}

             
            };
        }
    }     
                
               
}
