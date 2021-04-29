using StockManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.ViewModel
{
    public class CustomerSales
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int CustomerID { get; set; }
        public string BillNo { get; set; }

        public string Remarks { get; set; }

        
        public int Amount { get; set; }
        public string  ProductName { get; set; }
        public string  Category { get; set; }
        public int Price { get; set; }
       // public Stock stock { get; set; }

    }
}
