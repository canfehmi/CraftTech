using CraftTech.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftTech.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
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
