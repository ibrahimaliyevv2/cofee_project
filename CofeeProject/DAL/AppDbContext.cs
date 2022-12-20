using CofeeProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CofeeProject.DAL
{
    public class AppDbContext:IdentityDbContext
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
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Discounter> Discounters { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}
