using CofeeProject.DAL;
using CofeeProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CofeeProject.Areas.Manage.Controllers
{
    [Authorize]
    [Area("manage")]
    public class ContactsController : Controller
    {
        private readonly AppDbContext _context;
        public ContactsController(AppDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            List<Contact> contacts = _context.Contacts.ToList();
            return View(contacts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contact contact)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }


            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {

            Contact contact = _context.Contacts.FirstOrDefault(x => x.Id == id);

            if (contact == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            return View(contact);
        }
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Contact existContact = _context.Contacts.FirstOrDefault(x => x.Id == contact.Id);

            if (existContact == null)
            {
                return RedirectToAction("error", "dashboard");
            }


            existContact.LocationAdress = contact.LocationAdress;
            existContact.PhoneNumber = contact.PhoneNumber;
            existContact.EmailAdress = contact.EmailAdress;

            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Contact contact = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            return Ok();
        }
    }
}
