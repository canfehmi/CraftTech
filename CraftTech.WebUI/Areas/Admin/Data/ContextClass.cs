using CraftTech.DataAccessLayer.Concrete;
using CraftTech.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CraftTech.WebUI.Areas.Admin.Data
{
    public class ContextClass:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-E7MGKIP;initial catalog=CraftTechDb;integrated security=true;TrustServerCertificate=True");
        }
        DbSet<AboutUs> AboutUs { get; set; }
        DbSet<Banner> Banners { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Process> Processes { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<Subscribe> Subscribes { get; set; }
    }
}
