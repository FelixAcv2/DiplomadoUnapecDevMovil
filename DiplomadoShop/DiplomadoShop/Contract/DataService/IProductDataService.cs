using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiplomadoShop.Contract.DataService
{
  public interface IProductDataService
    {
        Task<IEnumerable<Product>> ProductsAsync();


    }
}
