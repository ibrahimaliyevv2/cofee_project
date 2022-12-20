using CofeeProject.DAL;
using CofeeProject.Helpers;
using CofeeProject.Models;
using CofeeProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CofeeProject.Areas.Manage.Controllers
{
    [Authorize]
    [Area("manage")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public ProductsController(AppDbContext context, IWebHostEnvironment environment)
        {
          _context= context;
          _environment = environment;
        }
        public IActionResult Index()
        {
            List<ProductCategory> categories = _context.ProductCategories.ToList();
            List<Product> products = _context.Products.Include(x=>x.Category).ToList();

            MenuViewModel menuVM = new MenuViewModel
            {
                ProductCategories = categories,
                Products = products
            };
            return View(menuVM);
        }
        public IActionResult Create() {

            List<ProductCategory> categories = _context.ProductCategories.ToList();
            ViewBag.ProductCategories = new SelectList(categories, "Id", "Name");
            return View();

        }

        [HttpPost]
        public IActionResult Create(Product product) {

            if (product.Image != null)
            {
                if (product.Image.ContentType != "image/png" && product.Image.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("Image", "File format should be either png or jpeg only.");
                }

                if (product.Image.Length > 2097152) // If file size is greater than 2 MB
                {
                    ModelState.AddModelError("Image", "File size should be less than 2 MB.");
                }
            }
            else
            {
                ModelState.AddModelError("Image", "Image file is required.");
            }
          

            if (!ModelState.IsValid)
            {
                return View();
            }



            product.ImageUrl = FileManager.Save(_environment.WebRootPath, "uploads/products", product.Image);

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            List<ProductCategory> categories = _context.ProductCategories.ToList();
            ViewBag.ProductCategories = new SelectList(categories, "Id", "Name");

            Product product = _context.Products.FirstOrDefault(x => x.Id == id);

            if(product == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            Product existProduct = _context.Products.FirstOrDefault(x => x.Id == product.Id);

            if(existProduct == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            if (product.Image != null)
            {
                if (product.Image.ContentType != "image/png" && product.Image.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("Image", "File format should be either png or jpeg only.");
                }

                if (product.Image.Length > 2097152) // If file size is greater than 2 MB
                {
                    ModelState.AddModelError("Image", "File size should be less than 2 MB.");
                }


                string newFileName = FileManager.Save(_environment.WebRootPath, "uploads/products", product.Image);

                FileManager.Delete(_environment.WebRootPath, "uploads/products", existProduct.ImageUrl);

                existProduct.ImageUrl= newFileName;

            }
           

            existProduct.Name = product.Name;
            existProduct.Description = product.Description;
            existProduct.CategoryId = product.CategoryId;
            existProduct.Price = product.Price;

            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return NotFound();
            }

            FileManager.Delete(_environment.WebRootPath, "uploads/products", product.ImageUrl);

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok();
        }
    }
}
