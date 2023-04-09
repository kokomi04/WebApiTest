using WebApiTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WebApiTest.EF
{
    public class MyDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    //optionsBuilder.UseSqlServer("Server=DESKTOP-HTUGB5I\\SQLEXPRESS; Database=Product; Trusted_Connection=true; encrypt=true;trustservercertificate=true;");
        //    optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyDetail> PropertyDetails { get; set; }
        public DbSet<ProductDetailPropertyDetail> ProductDetailPropertyDetails { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }

    }
}
