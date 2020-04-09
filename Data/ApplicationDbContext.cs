using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ISProject.Models;
using Microsoft.AspNetCore.Identity;
using ISProject.Utils;

namespace ISProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<IdentityUser> IdentityUser { get; set;}
        public DbSet<User> User { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductSale> ProductSale { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<NotiRole> NotiRole { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
        
        #region *******************Seeding Data*******************
            
            for(int i=1;i<=10;i++){
                //Seeding 10 products...
                modelBuilder.Entity<Product>()
                    .HasData(new Product(){Id=i*10,Name="Producto" + i.ToString(), 
                             Description="Descripcion del producto" + i.ToString()    });

                //Seeding 10 users(customers)
                RegisterUser(modelBuilder,(i*10 + 1).ToString(),SD.CustomerUser,"Customer"+i.ToString() );

                //Seeding 10 seller
                RegisterSeller(modelBuilder, (i*10 + 2).ToString(), SD.SellerUser, "Seller" +i.ToString() );

                // //Seeding 10 products sales
                modelBuilder.Entity<ProductSale>()
                    .HasData(new ProductSale()
                        {Id= i *1000 + 3, 
                        ProductId= i*10,
                        SellerId=(i*10 + 2).ToString(),
                        Units= i,
                        Price = i/2
                    });
                
                //Seeding Notifications of Role Upgrade
                if(i%3 ==0){
                    modelBuilder.Entity<NotiRole>()
                        .HasData(new NotiRole(){
                            Id=i*10+4,
                            UserID = (i*10 + 1).ToString(),
                            Message = "Customer" +i.ToString() + "wants to become a Seller",
                            SendToUser = "All_A",
                            Seen= false
                        });
                }

                
            }
            //Defining Roles
            string [] roles = {SD.CustomerUser,SD.ManagerUser,SD.SellerUser};
            foreach(var role in roles){    
                
                modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole()
                {
                    Id = "a18be9c0"+ role,
                    Name = role,
                    NormalizedName = role
                });
            }

            //Adding an Admin
            RegisterUser(modelBuilder,"21123111111",SD.ManagerUser,"admin");
        #endregion
               


        }
        private void RegisterUser(ModelBuilder modelBuilder,string id, string role, string name )
        {
            string User_ID = id;
            string ROLE_ID = "a18be9c0"+ role;  
            
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = User_ID,
                Name = name,
                UserName = name + "@fake.com",
                NormalizedUserName = (name + "@fake.com").ToUpper(),
                Email = name + "@fake.com",
                NormalizedEmail = (name + "@fake.com").ToUpper(),
                LockoutEnabled = true,
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "pass"),
                SecurityStamp = Guid.NewGuid().ToString()
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                
                RoleId = ROLE_ID,
                UserId = User_ID
            }); 

        }
        private void RegisterSeller(ModelBuilder modelBuilder,string id, string role, string name )
        {
            string Seller_ID = id;
            string ROLE_ID = "a18be9c0"+ role;
            
            
            var hasher = new PasswordHasher<Seller>();
            modelBuilder.Entity<Seller>().HasData(new Seller()
            {
                Id = Seller_ID,
                Name = name,
                UserName = name + "@fake.com",
                NormalizedUserName = (name + "@fake.com").ToUpper(),
                Email = name + "@fake.com",
                NormalizedEmail = (name + "@fake.com").ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "pass"),
                LockoutEnabled = true,
                SecurityStamp = Guid.NewGuid().ToString()
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = Seller_ID
            }); 

        }
    }
}
