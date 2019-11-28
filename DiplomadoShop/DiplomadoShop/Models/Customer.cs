using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomadoShop.Models
{
   public class Customer
    {
        [PrimaryKey,AutoIncrement]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string AddressReference { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string ImageUrl { get; set; }



    }
}
