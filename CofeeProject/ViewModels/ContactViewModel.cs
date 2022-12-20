using CofeeProject.Models;
using System.Collections.Generic;

namespace CofeeProject.ViewModels
{
    public class ContactViewModel
    {
        public List<Contact> Contacts { get; set; } 
        public Message message { get; set; }
    }
}
