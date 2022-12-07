using CofeeProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CofeeProject.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<AboutFeature> AboutFeatures { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
