using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFourthMVC.Models
{
    public class OrderDetailsViewModel
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public virtual OrderViewModel Orders { get; set; }
        public virtual ProductsViewModel Products { get; set; }
    }
}