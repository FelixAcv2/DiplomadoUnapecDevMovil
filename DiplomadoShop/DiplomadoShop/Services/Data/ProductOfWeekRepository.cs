using DiplomadoShop.Contract.Data;
using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiplomadoShop.Services.Data
{
    public class ProductOfWeekRepository : IProductRepository
    {
        public async Task<IEnumerable<Product>> ProductsAsync()
        {
            var _task = Task.Run<List<Product>>(() =>
            {
                return new List<Product> {
                 new Product{ProductId = 1,Name = "GL503GE-ES73 (8a generación)",Price = 64985.23m,ImageUrl = "AC_UY218_ML3_.jpg",
                              LongDescription = "Rog Strix Hero Edition gaming Laptop is designed for multiplayer online battle arena (MOBA) players, optimized to deliver a competitive edge. You'll lead the way armed with powerful Intel Core i7 processors and NVIDIA GeForce GTX 10-series graphics. Strix Hero Edition packs a rich-color, 120Hz wide-view display",
                               ShortDescription = "Asus ROG Strix Hero Edition Gaming Laptop, 15.6” FHD 120Hz 3M, 8th-Gen Intel Core i7-8750H Processor, GeForce GTX 1050 Ti 4GB, 16GB DDR4, 128GB PCIe...", 
                                InStock = true,IsProductOfTheWeek = true

                  }

                 };
            });

            return await _task;
        }
    }
}
