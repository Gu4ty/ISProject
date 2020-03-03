using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ISProject.Data.Models;

namespace ISProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Users2 { get; set; }
        public DbSet<NormalUser> NormalUsers { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sell> Sells { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
