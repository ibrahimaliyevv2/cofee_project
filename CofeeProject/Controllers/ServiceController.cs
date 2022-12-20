using CofeeProject.DAL;
using CofeeProject.Models;
using CofeeProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CofeeProject.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        public ServiceController(AppDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            List<Service> services = _context.Services.ToList();

            ServiceViewModel serviceVM = new ServiceViewModel
            {
                Services = services
            };

            return View(serviceVM);
        }
    }
}
