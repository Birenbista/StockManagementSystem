using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMS.Data;
using SMS.ViewModel;
using StockManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult CustomerSales( int ProductID)
            {
            if (ProductID != 0)
            {
                
                var p = _context.Product.Where(p => p.ProductID == ProductID).FirstOrDefault();
                TempData["ProductName"] = p.Name;
                TempData["Category"] = _context.Category.Where(c => c.CategoryID == p.CategoryID).Select(p => p.Name).First();
            }
            else
            {
                ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID");
                ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID");
                var p = _context.Product.First();
                TempData["ProductName"] = p.Name;

                TempData["Category"] = _context.Category.Where(c => c.CategoryID == p.CategoryID).Select(p => p.Name).First();

                //System.Diagnostics.Debug.WriteLine(ViewData["Category"].Values);
                //ViewData["Price"] = new SelectList(_context.Customer, "Name", "Name");
            }

                return View();
            
        }
        public async Task<IActionResult> Create([Bind("ProductID,Quantity,CustomerID,Amount,BillNo,Remarks")] CustomerSales csales)
        {
            Sales sales = new Sales();
            sales.CustomerID = csales.CustomerID;
            sales.SalesDate = DateTime.Now;
            sales.BillNo = csales.BillNo;
            sales.Remarks = csales.Remarks;
            _context.Sales.Add(sales);
            await _context.SaveChangesAsync();

            SalesDetail salesDetail = new SalesDetail();
            salesDetail.SalesID = _context.Sales.Where(p => p.BillNo == csales.BillNo).Select(s => s.SalesID).First();
            salesDetail.ProductID = csales.ProductID;
            salesDetail.Quantity = csales.Quantity;
            salesDetail.Amount = csales.Amount;
            _context.SalesDetail.Add(salesDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CustomerSales));



        }
    }
}
