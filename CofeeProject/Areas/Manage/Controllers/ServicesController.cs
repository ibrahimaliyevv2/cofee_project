using CofeeProject.DAL;
using CofeeProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CofeeProject.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ServicesController : Controller
    {
        private AppDbContext _context;
        public ServicesController(AppDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            List<Service> services = _context.Services.ToList();

            return View(services);
        }
    }
}
