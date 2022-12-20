using CofeeProject.DAL;
using CofeeProject.Helpers;
using CofeeProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CofeeProject.Areas.Manage.Controllers
{
    [Authorize]
    [Area("manage")]
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            List<ProductCategory> categories = _context.ProductCategories.Include(x=>x.Products).ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCategory category)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }


            _context.ProductCategories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {

            ProductCategory category = _context.ProductCategories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(ProductCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ProductCategory existCategory = _context.ProductCategories.FirstOrDefault(x => x.Id == category.Id);

            if (existCategory == null)
            {
                return RedirectToAction("error", "dashboard");
            }


            existCategory.Name = category.Name;

            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            ProductCategory category = _context.ProductCategories.Include(x => x.Products).FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Products.RemoveRange(category.Products);
            _context.ProductCategories.Remove(category);
            _context.SaveChanges();

            return Ok();
        }
    }
}
