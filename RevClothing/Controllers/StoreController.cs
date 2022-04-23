using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using RevClothing.Models;
using RevClothing.Data;
using System.Diagnostics;




namespace RevClothing.Controllers

{

    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? c)
        {
            var products = _context.Products.Include(p => p.Category).ToList();
            if (c != null)
            {
                products = products.Where(p => p.CategoryID == (int)c).ToList();
            }
            var categories = _context.Category.Include(c => c.CategoryName).ToList();
            var record = new Store()
            {
                ProductList = products,
                CategoryList = categories
            };
            return View(record);
        }
    }        
    //[Authorize]
    //public IActionResult AddToCart(int? id, int? quantity)
    //{
    //    if(id == null)
    //    {
    //        return RedirectToAction("Index");
    //    }

    //}
}


