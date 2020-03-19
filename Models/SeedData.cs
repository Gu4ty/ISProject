
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ISProject.Data;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;


namespace ISProject.Models
{

    public static class SeedData{

        public static void Init(IServiceProvider serviceProvider){
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if(!context.User.Any()){
                    context.User.AddRange(
                        new User { UserName = "pepito@gmail.com", Email = "pepito@gmail.com",
                            Name = "Pepito", PhoneNumber = "324222343", Raiting = 0
                        }

                    );

                }

            }
        }
    
    }



}