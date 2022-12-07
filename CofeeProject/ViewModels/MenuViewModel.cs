using CofeeProject.Models;
using System.Collections.Generic;

namespace CofeeProject.ViewModels
{
    public class MenuViewModel
    {
        public List<ProductCategory> ProductCategories { get; set; }
        public List<Product> Products { get; set; }
    }
}
