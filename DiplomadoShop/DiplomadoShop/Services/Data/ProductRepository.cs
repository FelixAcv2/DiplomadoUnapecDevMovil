using DiplomadoShop.Contract.Data;
using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiplomadoShop.Services.Data
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {

        }
        public async Task<IEnumerable<Product>> ProductsAsync()
        {
           var _task= Task.Run<List<Product>>(()=>
          {
            return    new List<Product> {
                 new Product{Id = 1,Name = "Logitech Desktop MK120",Price = 956.23m,ImageUrl = "ic_keyboard_product.png",  
                              LongDescription = "Input Device:	Keyboard Pointing Device:Mouse Miscellaneous",
                               ShortDescription = "Logitech Desktop MK120 keyboard and mouse set English", InStock = true,IsProductOfTheWeek = false

                  }

                 };
            });

            return await _task;
        }
    }
}
