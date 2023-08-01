using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if(context.Users.Any()) return;

            var users = new List<User>
            {
                new User() 
                { 
                    Id = 1,
                    Name = "Piotr",
                    Surrname = "Kowalski"
                },
                new User() 
                { 
                    Id = 2,
                    Name = "Rafal",
                    Surrname = "Kowalski"
                },
                new User() 
                { 
                    Id = 3,
                    Name = "Wiktor",
                    Surrname = "Nowak"
                }
            };
            
            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();

            if(context.Companies.Any()) return;

            var leader1 = await context.Users.FindAsync(1);
            var leader2 = await context.Users.FindAsync(2);

            var companies = new List<Company>
            {
                new Company() 
                { 
                    Name = "Asus",
                    Description = "Hardware",
                    Leader = leader2
                },
                new Company() 
                { 
                    Name = "Lockhead Martin",
                    Description = "Military",
                    Leader = leader1
                }
            };



            await context.Companies.AddRangeAsync(companies);
            await context.SaveChangesAsync();
            
            //Add leaders to companies
            
        }
    }
}