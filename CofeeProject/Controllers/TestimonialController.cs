using CofeeProject.DAL;
using CofeeProject.Models;
using CofeeProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CofeeProject.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _context;
        public TestimonialController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Visitor> visitors = _context.Visitors.ToList();
            TestimonialViewModel testimonialVMm = new TestimonialViewModel
            {
                Visitors = visitors
            };

            return View(testimonialVMm);
        }
    }
}
