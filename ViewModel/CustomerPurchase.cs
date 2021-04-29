using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.ViewModel
{
    public class CustomerPurchase
    {
        public string CustomerName { get; set; }
        public string Product { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string BillNo { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
    }
}
