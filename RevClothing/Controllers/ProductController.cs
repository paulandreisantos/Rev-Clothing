using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RevClothing.Data;
using RevClothing.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace RevClothing.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Products.Include(p => p.Category).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product record)
        {
            var selectedCategory = _context.Category.Where(c => c.CategoryID == record.CategoryID).SingleOrDefault();

            var product = new Product();
            product.ProductName = record.ProductName;
            product.Price = record.Price;
            product.Description = record.Description;
            product.Category = selectedCategory;
            product.CategoryID = record.CategoryID;




            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var product = _context.Products.Where(p => p.ProductID == id).SingleOrDefault();
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Product record)
        {
            var product = _context.Products.Where(p => p.ProductID == id).SingleOrDefault();
            var selectedCategory = _context.Category.Where(c => c.CategoryID == record.CategoryID).SingleOrDefault();

            product.ProductName = record.ProductName;
            product.Price = record.Price;
            product.Description = record.Description;
            product.Category = selectedCategory;
            product.CategoryID = record.CategoryID;



            _context.Products.Update(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var product = _context.Products.Where(p => p.ProductID == id).SingleOrDefault();
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}