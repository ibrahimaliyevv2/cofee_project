using CofeeProject.DAL;
using CofeeProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CofeeProject.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SlidersController : Controller
    {
        private AppDbContext _context;
        public SlidersController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();

            return View(sliders);
        }
    }
}
