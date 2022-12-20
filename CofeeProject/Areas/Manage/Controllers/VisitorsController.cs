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
    public class VisitorsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public VisitorsController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context= context;
            _environment= environment;
        }
        public IActionResult Index()
        {
            List<Visitor> visitors = _context.Visitors.ToList();

            return View(visitors);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Visitor visitor)
        {

            if (visitor.Image != null)
            {
                if (visitor.Image.ContentType != "image/png" && visitor.Image.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("Image", "File format should be either png or jpeg only.");
                }

                if (visitor.Image.Length > 2097152)
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



            visitor.ImageUrl = FileManager.Save(_environment.WebRootPath, "uploads/visitors", visitor.Image);

            _context.Visitors.Add(visitor);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Visitor visitor = _context.Visitors.FirstOrDefault(x => x.Id == id);

            if (visitor == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            return View(visitor);
        }

        [HttpPost]
        public IActionResult Edit(Visitor visitor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Visitor existVisitor = _context.Visitors.FirstOrDefault(x => x.Id == visitor.Id);

            if (existVisitor == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            if (visitor.Image != null)
            {
                if (visitor.Image.ContentType != "image/png" && visitor.Image.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("Image", "File format should be either png or jpeg only.");
                }

                if (visitor.Image.Length > 2097152)
                {
                    ModelState.AddModelError("Image", "File size should be less than 2 MB.");
                }


                string newFileName = FileManager.Save(_environment.WebRootPath, "uploads/visitors", visitor.Image);

                FileManager.Delete(_environment.WebRootPath, "uploads/sliders", existVisitor.ImageUrl);

                existVisitor.ImageUrl = newFileName;

            }


            existVisitor.Name = visitor.Name;
            existVisitor.Job = visitor.Job;
            existVisitor.Comment = visitor.Comment;

            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Visitor visitor = _context.Visitors.FirstOrDefault(x => x.Id == id);

            if (visitor == null)
            {
                return NotFound();
            }

            FileManager.Delete(_environment.WebRootPath, "uploads/visitors", visitor.ImageUrl);

            _context.Visitors.Remove(visitor);
            _context.SaveChanges();

            return Ok();
        }
    }
}
