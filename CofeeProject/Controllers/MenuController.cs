using CofeeProject.DAL;
using CofeeProject.Models;
using CofeeProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CofeeProject.Controllers
{
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;
        public MenuController(AppDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            List<ProductCategory> productCategories = _context.ProductCategories.ToList();
            List<Product> products = _context.Products.Include(x=>x.Category).ToList();

            MenuViewModel menuViewModel = new MenuViewModel
            {
                ProductCategories = productCategories,
                Products = products
            };
            return View(menuViewModel);
        }
    }
}
