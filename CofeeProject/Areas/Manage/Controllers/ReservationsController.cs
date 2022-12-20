using CofeeProject.DAL;
using CofeeProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CofeeProject.Areas.Manage.Controllers
{
    [Authorize]
    [Area("manage")]
    public class ReservationsController : Controller
    {
        private readonly AppDbContext _context;
        public ReservationsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Reservation> reservations = _context.Reservations.ToList();
            
            return View(reservations);
        }
        public IActionResult Delete(int id)
        {
            Reservation reservation = _context.Reservations.FirstOrDefault(x => x.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();

            return Ok();
        }
    }
}
