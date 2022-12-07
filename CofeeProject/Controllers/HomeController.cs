using CofeeProject.DAL;
using CofeeProject.Models;
using CofeeProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CofeeProject.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            List<AboutFeature> aboutFeatures = _context.AboutFeatures.ToList();
            List<Service> services = _context.Services.ToList(); 
            List<ProductCategory> productCategories = _context.ProductCategories.ToList();
            List<Product> products = _context.Products.Include(x => x.Category).ToList();
            List<Visitor> visitors = _context.Visitors.ToList();

            HomeViewModel homeVM = new HomeViewModel
            {
                Sliders = sliders,
                AboutFeatures = aboutFeatures,
                Services = services,
                ProductCategories= productCategories,
                Products = products,
                Visitors = visitors
            }; 

            return View(homeVM);
        }

        public IActionResult About()
        {
            List<AboutFeature> aboutFeatures = _context.AboutFeatures.ToList();

            AboutViewModel aboutVM = new AboutViewModel
            {
                AboutFeatures = aboutFeatures
            };

            return View(aboutVM);
        }

        public IActionResult Contact()
        {

            List<Contact> contacts = _context.Contacts.ToList();
            ContactViewModel contactVM = new ContactViewModel
            {
                Contacts = contacts
            };

            return View(contactVM);
        }
    }
}
