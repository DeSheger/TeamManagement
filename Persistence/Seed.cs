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
                    Name = "Piotr",
                    Surname = "Kowalski"
                },
                new User() 
                { 
                    Name = "Rafal",
                    Surname = "Kowalski"
                },
                new User() 
                { 
                    Name = "Wiktor",
                    Surname = "Nowak"
                }
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}