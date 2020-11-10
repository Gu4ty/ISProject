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
        public DbSet<NotiBuy> NotiBuy { get; set; }
        public DbSet<NotiSell> NotiSell { get; set; }
        public DbSet<NotiAuction> NotiAuction { get; set; }
        
        public DbSet<OrderDetails> OrderDetails {get; set; }
        public DbSet<OrderHeader> OrderHeader {get; set; }
        public DbSet<AuctionHeader> AuctionHeader {get; set; }
        public DbSet<AuctionProduct> AuctionProduct {get; set; }
        public DbSet<AuctionUser> AuctionUser {get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NotiBuy>()
                .HasMany(n => n.OrderDetails)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<NotiSell>()
                .HasMany(n => n.OrderDetails)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);



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

                //Seeding 10 products sales
                modelBuilder.Entity<ProductSale>()
                    .HasData(new ProductSale()
                        {Id= i *1000 + 3, 
                        ProductId= i*10,
                        SellerId=(i*10 + 2).ToString(),
                        Units= i + 1,
                        Price = (i + 15) / 2,
                        Image = @"/images/default.png"
                    });
                
                
                //Seeding Notifications of Role Upgrade
                if(i%3 ==0){
                    modelBuilder.Entity<NotiRole>()
                        .HasData(new NotiRole(){
                            Id=i*10+4,
                            UserID = (i*10 + 1).ToString(),
                            Message = "Customer" +i.ToString() + " wants to become a Seller",
                            SendToUser = "All_A",
                            Seen= false
                        });
                }

                //Seeding Auctions
                if(i%2 != 0)
                {
                    AuctionHeader ah;
                    
                    if(i==3 || i==5) // Seeding two Ended Auctions
                    {
                        ah = new AuctionHeader()
                        {
                            BeginDate = DateTime.Now,
                            CurrentPrice = i+3,
                            EndDate = DateTime.Now,
                            Id = i*10 + 5,
                            PriceStep = i,
                            SellerId = (i*10 + 2).ToString()
                        };   
                    }
                    else if(i==1) //Seeding an upcoming auction
                    {
                        ah = new AuctionHeader()
                        {
                            BeginDate = DateTime.Now.AddHours(5),
                            CurrentPrice = i,
                            EndDate = DateTime.Now.AddHours(i+10),
                            Id = i*10 + 5,
                            PriceStep = i,
                            SellerId = (i*10 + 2).ToString()
                        };
                        
                    }
                    else
                    {
                        ah = new AuctionHeader()
                        {
                            BeginDate = DateTime.Now,
                            CurrentPrice = i+3,
                            EndDate = DateTime.Now.AddHours(i+10),
                            Id = i*10 + 5,
                            PriceStep = i,
                            SellerId = (i*10 + 2).ToString()
                        };

                    }

                    var ap = new AuctionProduct()
                    {
                        AuctionId = i*10 +5,
                        Id = i*10+6,
                        ProductId = i*10,
                        Quantity = (i+1)/2,
                    };

                    
                    var ap1 = new AuctionProduct()
                    {
                        AuctionId = i*10 +5,
                        Id = i*100000+6,
                        ProductId = (i+1)*10,
                        Quantity = (i+1)/2,
                    };

                    if(i!= 5 && i!=1){ // The auction 5 and 1 does not contain an auctionUser
                        
                        if(i==3) // Auction 3 has two auctionUser
                        {
                            var auser2= new AuctionUser()
                            {
                                Id=i*10000000 +7,
                                AuctionId = i*10 +5,
                                UserId = ((i+1)*10 + 1).ToString(),
                                LastPriceOffered = i+1
                            };
                            
                            modelBuilder.Entity<AuctionUser>()
                                .HasData(auser2); 
                        }

                        var auser= new AuctionUser()
                        {
                            Id=i*10 +7,
                            AuctionId = i*10 +5,
                            UserId = (i*10 + 1).ToString(),
                            LastPriceOffered = i+3
                        };
                        modelBuilder.Entity<AuctionUser>()
                            .HasData(auser); 
                    }

                    modelBuilder.Entity<AuctionHeader>()
                        .HasData(ah);
                    
                    modelBuilder.Entity<AuctionProduct>()
                        .HasData(ap);
                    
                    modelBuilder.Entity<AuctionProduct>()
                        .HasData(ap1);

                    
                        
                }

                
            }

            //Adding just one more product sale, Seller 8 is selling product 1
            modelBuilder.Entity<ProductSale>()
                    .HasData(new ProductSale()
                        {Id= 8 *10000 + 3, 
                        ProductId= 1*10,
                        SellerId=(8*10 + 2).ToString(),
                        Units= 8 + 1,
                        Price = (8 + 15) / 2
                    });

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
            RegisterSeller(modelBuilder,"21123111111",SD.ManagerUser,"admin");
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
