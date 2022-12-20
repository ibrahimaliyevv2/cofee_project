using CofeeProject.DAL;
using CofeeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CofeeProject.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly AppDbContext _context;
        public SubscriberController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Index(Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Subscribers.Add(subscriber);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
