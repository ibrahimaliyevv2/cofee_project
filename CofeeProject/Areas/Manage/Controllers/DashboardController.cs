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
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            List<Message> messages = _context.Messages.ToList();
            return View(messages);
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
