using CofeeProject.Models;
using System.Collections.Generic;

namespace CofeeProject.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<AboutFeature> AboutFeatures { get; set; }
        public List<Service> Services  { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<Product> Products { get; set; }
        public List<Visitor> Visitors { get; set; }
        public Reservation reservation { get; set; }
    }
}
