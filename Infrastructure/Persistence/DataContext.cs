using Domain.Entities;
using Domain.FluentApi;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DataContext : IdentityDbContext<ApplicationUser, AppRole, string>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Module>(new ModuleFluentApi());
            base.OnModelCreating(builder);
        }
    }

}
