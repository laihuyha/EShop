using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.ViewModel
{
    public class Cart
    {
        public Product product { get; set; }
        public decimal Cost { get; set; }
        public decimal Total => Cost * product.SalesPrice.Value;
    }
}
