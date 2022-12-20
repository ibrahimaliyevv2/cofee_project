using CofeeProject.DAL;
using CofeeProject.Helpers;
using CofeeProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CofeeProject.Areas.Manage.Controllers
{
    [Authorize]
    [Area("manage")]
    public class SlidersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public SlidersController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();

            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {

            if (slider.Image != null)
            {
                if (slider.Image.ContentType != "image/png" && slider.Image.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("Image", "File format should be either png or jpeg only.");
                }

                if (slider.Image.Length > 2097152) 
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



            slider.ImageUrl = FileManager.Save(_environment.WebRootPath, "uploads/sliders", slider.Image);

            _context.Sliders.Add(slider) ;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            if (slider == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            return View(slider);
        }

        [HttpPost]
        public IActionResult Edit(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Slider existSlider = _context.Sliders.FirstOrDefault(x => x.Id == slider.Id);

            if (existSlider == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            if (slider.Image != null)
            {
                if (slider.Image.ContentType != "image/png" && slider.Image.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("Image", "File format should be either png or jpeg only.");
                }

                if (slider.Image.Length > 2097152) 
                {
                    ModelState.AddModelError("Image", "File size should be less than 2 MB.");
                }


                string newFileName = FileManager.Save(_environment.WebRootPath, "uploads/sliders", slider.Image);

                FileManager.Delete(_environment.WebRootPath, "uploads/sliders", existSlider.ImageUrl);

                existSlider.ImageUrl = newFileName;

            }


            existSlider.Description = slider.Description;
            existSlider.Title = slider.Title;
            existSlider.Subtitle = slider.Subtitle;

            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            if (slider == null)
            {
                return NotFound();
            }

            FileManager.Delete(_environment.WebRootPath, "uploads/sliders", slider.ImageUrl);

            _context.Sliders.Remove(slider);
            _context.SaveChanges();

            return Ok();
        }
    }
}
