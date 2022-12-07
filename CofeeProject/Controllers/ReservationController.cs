using Microsoft.AspNetCore.Mvc;

namespace CofeeProject.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
