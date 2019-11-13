using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiplomadoShop.Contract.Data
{
  public  interface IProductRepository
    {
        Task<IEnumerable<Product>> ProductsAsync();
   
    }
}
