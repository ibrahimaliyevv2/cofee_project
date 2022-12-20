using CofeeProject.DAL;
using CofeeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CofeeProject.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;
        public ReservationController(AppDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(Reservation reservation)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
