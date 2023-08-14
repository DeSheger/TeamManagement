using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<User> userManager)
        {
            //Add users
            if (!userManager.Users.Any())
            {
                var users = new List<User>
                {
                new User()
                {
                    Id = 1,
                    Name = "Piotr",
                    Surrname = "Kowalski",
                    Email = "piotr@test.com"
                },
                new User()
                {
                    Id = 2,
                    Name = "Rafal",
                    Surrname = "Kowalski",
                    Email = "rafal@test.com"
                },
                new User()
                {
                    Id = 3,
                    Name = "Wiktor",
                    Surrname = "Nowak",
                    Email = "wiktor@test.com"
                }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }

                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }


            //Add companies
            if (context.Companies.Any()) return;

            var user1 = await context.Users.FindAsync(1);
            var user2 = await context.Users.FindAsync(2);
            var user3 = await context.Users.FindAsync(3);

            List<User> userGroup1 = new List<User>();
            userGroup1.Add(user1);
            userGroup1.Add(user2);
            userGroup1.Add(user3);
            List<User> userGroup2 = new List<User>();
            userGroup2.Add(user1);
            userGroup2.Add(user2);
            List<User> userGroup3 = new List<User>();
            userGroup3.Add(user2);
            userGroup3.Add(user3);


            var companies = new List<Company>
            {
                new Company()
                {
                    Id = 1,
                    Name = "Asus",
                    Description = "Hardware",
                    Leader = user1,
                    Members = userGroup1
                },
                new Company()
                {
                    Id = 2,
                    Name = "Lockhead Martin",
                    Description = "Military",
                    Leader = user2,
                    Members = userGroup3
                }
            };

            await context.Companies.AddRangeAsync(companies);
            await context.SaveChangesAsync();

            //Add Groups
            if (context.Groups.Any()) return;

            var company1 = await context.Companies.FindAsync(1);
            var company2 = await context.Companies.FindAsync(2);

            var groups = new List<Group>
            {
                new Group()
                {
                    Id = 1,
                    Name = "Backend",
                    Description = "Backend dev",
                    Leader = user3,
                    Company = company1,
                    Members = userGroup2

                },
                new Group()
                {
                    Id = 2,
                    Name = "Frontend",
                    Description = "Frontend dev",
                    Leader = user1,
                    Company = company1,
                    Members = userGroup3
                },
                new Group()
                {
                    Id = 3,
                    Name = "Soldiers",
                    Description = "Soldiers Group",
                    Leader = user2,
                    Company = company2,
                    Members = userGroup3

                },
            };

            await context.Groups.AddRangeAsync(groups);
            await context.SaveChangesAsync();

            //Add activities
            if (context.Activities.Any()) return;

            var group1 = await context.Groups.FindAsync(1);
            var group2 = await context.Groups.FindAsync(2);
            var group3 = await context.Groups.FindAsync(3);

            var activities = new List<Activity>
            {
                new Activity()
                {
                    Title = "Login screen",
                    Description = "New login screen view",
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddMonths(2),
                    Author = user1,
                    Company = company1,
                    Group = group2,
                    Members = userGroup2,
                },
                new Activity()
                {
                    Title = "Home screen",
                    Description = "New home screen view",
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddMonths(1),
                    Author = user2,
                    Company = company1,
                    Group = group2,
                    Members = userGroup3,
                },
                new Activity()
                {
                    Title = "Sahara exploration",
                    Description = "Explore south of Sahara",
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddMonths(2),
                    Author = user2,
                    Company = company2,
                    Group = group3,
                    Members = userGroup3,
                },
                new Activity()
                {
                    Title = "UsersController",
                    Description = "Add methods in UserController",
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddMonths(3),
                    Author = user2,
                    Company = company1,
                    Group = group1,
                    Members = userGroup2,
                },
            };

            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}