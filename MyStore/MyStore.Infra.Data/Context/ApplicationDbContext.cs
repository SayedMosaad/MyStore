using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain;
using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infra.Data.Context
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().Property(x => x.Name).HasMaxLength(250);
            builder.Entity<Category>().Property(x => x.ImageUrl).HasMaxLength(500);


            builder.Entity<Product>().Property(x => x.Name).HasMaxLength(250);
            builder.Entity<Product>().Property(x => x.Description).HasMaxLength(500);
            builder.Entity<Product>().Property(x => x.ImageUrl).HasMaxLength(500);



            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admin", NormalizedName = "ADMIN".ToUpper() });


            var hasher = new PasswordHasher<ApplicationUser>();


            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Pass@123")
                }
            );


            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );

        }
    }
}
