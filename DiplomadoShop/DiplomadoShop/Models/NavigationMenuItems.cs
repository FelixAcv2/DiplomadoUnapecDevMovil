using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomadoShop.Models
{
   public class NavigationMenuItems
    {
        public string Title { get; set; }
        public string Icon { get; set; }

        public Type ViewType { get; set; }

        public NavigationMenuItems()
        {

        }
    }
}
