using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class CustomerSalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerSalesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CustomerPurchase([FromQuery] string customer)
        {

            List<CustomerPurchase> lstData = new List<CustomerPurchase>();
            if (string.IsNullOrEmpty(customer))
            {

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT c.Name, s.SalesDate as PurchaseDate, s.BillNo, sd.Quantity, sd.Amount, p.Name as Product from customer c inner join sales s on c.CustomerID=s.CustomerID inner join SalesDetail sd on sd.SalesID=s.SalesID inner join Product p on p.ProductID=sd.ProductID";
                    _context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        CustomerPurchase data;
                        while (result.Read())
                        {
                            data = new CustomerPurchase();
                            data.CustomerName = result.GetString(0);
                            data.PurchaseDate = result.GetDateTime(1);
                            data.BillNo = result.GetString(2);
                            data.Quantity = result.GetInt32(3);
                            data.Amount = result.GetInt32(4);
                            data.Product = result.GetString(5);
                            
                            lstData.Add(data);
                        }
                    }
                }
            }
            else
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    int CustomerID;
                    bool parse = int.TryParse(customer, out CustomerID);
                    if (parse)
                    {
                    command.CommandText = "SELECT c.Name, s.SalesDate as PurchaseDate, s.BillNo, sd.Quantity, sd.Amount, p.Name as Product from customer c inner join sales s on c.CustomerID=s.CustomerID inner join SalesDetail sd on sd.SalesID=s.SalesID inner join Product p on p.ProductID=sd.ProductID where c.CustomerID='"+ CustomerID+"'";

                    }
                    else
                    {
                        command.CommandText = "SELECT c.Name, s.SalesDate as PurchaseDate, s.BillNo, sd.Quantity, sd.Amount, p.Name as Product from customer c inner join sales s on c.CustomerID=s.CustomerID inner join SalesDetail sd on sd.SalesID=s.SalesID inner join Product p on p.ProductID=sd.ProductID where c.Name='" + customer + "'";
                    }
                    _context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        CustomerPurchase data;
                        while (result.Read())
                        {
                            data = new CustomerPurchase();
                            data.CustomerName = result.GetString(0);
                            data.PurchaseDate = result.GetDateTime(1);
                            data.BillNo = result.GetString(2);
                            data.Quantity = result.GetInt32(3);
                            data.Amount = result.GetInt32(4);
                            data.Product = result.GetString(5);

                            lstData.Add(data);
                        }
                    }
                }
            }
            return View(lstData);

        }
    }
}
