using CofeeProject.DAL;
using CofeeProject.Helpers;
using CofeeProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CofeeProject.Areas.Manage.Controllers
{
    [Authorize]
    [Area("manage")]
    public class ServicesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public ServicesController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context= context;
            _environment= environment;
        }
        public IActionResult Index()
        {
            List<Service> services = _context.Services.ToList();

            return View(services);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {

            if (service.Image != null)
            {
                if (service.Image.ContentType != "image/png" && service.Image.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("Image", "File format should be either png or jpeg only.");
                }

                if (service.Image.Length > 2097152)
                {
                    ModelState.AddModelError("Image", "File size should be less than 2 MB.");
                }
            }
            else
            {
                ModelState.AddModelError("Image", "Image file is required.");
            }


            if (!ModelState.IsValid)
            {
                return View();
            }



            service.ImageUrl = FileManager.Save(_environment.WebRootPath, "uploads/services", service.Image);

            _context.Services.Add(service);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Service service = _context.Services.FirstOrDefault(x => x.Id == id);

            if (service == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            return View(service);
        }

        [HttpPost]
        public IActionResult Edit(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Service existService = _context.Services.FirstOrDefault(x => x.Id == service.Id);

            if (existService == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            if (service.Image != null)
            {
                if (service.Image.ContentType != "image/png" && service.Image.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("Image", "File format should be either png or jpeg only.");
                }

                if (service.Image.Length > 2097152)
                {
                    ModelState.AddModelError("Image", "File size should be less than 2 MB.");
                }


                string newFileName = FileManager.Save(_environment.WebRootPath, "uploads/services", service.Image);

                FileManager.Delete(_environment.WebRootPath, "uploads/services", existService.ImageUrl);

                existService.ImageUrl = newFileName;

            }

            existService.IconUrl = service.IconUrl;
            existService.Title = service.Title;
            existService.Description = service.Description;


            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Service service = _context.Services.FirstOrDefault(x => x.Id == id);

            if (service == null)
            {
                return NotFound();
            }

            FileManager.Delete(_environment.WebRootPath, "uploads/services", service.ImageUrl);

            _context.Services.Remove(service);
            _context.SaveChanges();

            return Ok();
        }
    }
}
