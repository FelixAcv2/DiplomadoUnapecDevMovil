﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomadoShop.Models
{
   public class OrderDetailTmp
    {
        //  [PrimaryKey, AutoIncrement]
        public int OrderDetailTmpId { get; set; }

        public int ProductId { get; set; }

        public string Description { get; set; }

        public double TaxRate { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public decimal Total { get { return Price * (decimal)Quantity; } }

        // [ManyToOne]
        public Product Product { get; set; }

        public override int GetHashCode()
        {
            return OrderDetailTmpId;
        }
    }
}
