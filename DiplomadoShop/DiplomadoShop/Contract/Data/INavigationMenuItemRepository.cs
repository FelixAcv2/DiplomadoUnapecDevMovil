using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomadoShop.Contract.Data
{
  public  interface INavigationMenuItemRepository
    {
        List<NavigationMenuItems> LoadMenu();  
    }
}
