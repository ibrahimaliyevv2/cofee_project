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
    public class FeaturesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public FeaturesController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context= context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            List<AboutFeature> features = _context.AboutFeatures.ToList();

            return View(features);
        }
        public IActionResult Edit(int id)
        {

            AboutFeature feature = _context.AboutFeatures.FirstOrDefault(x => x.Id == id);

            if (feature == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            return View(feature);
        }

        [HttpPost]
        public IActionResult Edit(AboutFeature feature)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AboutFeature existFeature = _context.AboutFeatures.FirstOrDefault(x => x.Id == feature.Id);

            if (existFeature == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            if (feature.Image != null)
            {
                if (feature.Image.ContentType != "image/png" && feature.Image.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("Image", "File format should be either png or jpeg only.");
                }

                if (feature.Image.Length > 2097152) 
                {
                    ModelState.AddModelError("Image", "File size should be less than 2 MB.");
                }


                string newFileName = FileManager.Save(_environment.WebRootPath, "uploads/about", feature.Image);

                FileManager.Delete(_environment.WebRootPath, "uploads/about", existFeature.ImageUrl);

                existFeature.ImageUrl = newFileName;

            }


            existFeature.Title1 = feature.Title1;
            existFeature.Title2 = feature.Title2;
            existFeature.Title3 = feature.Title3;
            existFeature.Description1 = feature.Description1;
            existFeature.Description2 = feature.Description2;
            existFeature.Description3 = feature.Description3;
            existFeature.AddedText1 = feature.AddedText1;
            existFeature.AddedText2 = feature.AddedText2;
            existFeature.AddedText3 = feature.AddedText3;

            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
