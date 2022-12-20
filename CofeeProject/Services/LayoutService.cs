using CofeeProject.DAL;
using CofeeProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace CofeeProject.Services
{
    public class LayoutService
    {
        private AppDbContext _context;
        public LayoutService(AppDbContext context)
        {
            _context= context;
        }
        
        public Subscriber subscriber { get; set; }
        public Dictionary<string, string> GetSettings()
        {
            return _context.Settings.ToDictionary(x => x.Key, y => y.Value);
        }
    }
}
