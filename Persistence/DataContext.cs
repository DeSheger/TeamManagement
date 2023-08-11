using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Activity>()
                        .HasOne(a => a.Author)
                        .WithMany(u => u.ActivitiesAuthor);

            modelBuilder.Entity<Activity>()
                        .HasMany(a => a.Members)
                        .WithMany(u => u.ActivitiesToDo);

            modelBuilder.Entity<Company>()
                        .HasOne(a => a.Leader)
                        .WithMany(u => u.CompaniesLeader);

            modelBuilder.Entity<Company>()
                        .HasMany(a => a.Members)
                        .WithMany(u => u.CompaniesMember);

            modelBuilder.Entity<Group>()
                        .HasOne(a => a.Leader)
                        .WithMany(u => u.GroupsLeader);

            modelBuilder.Entity<Group>()
                        .HasMany(a => a.Members)
                        .WithMany(u => u.GroupsMember);

            base.OnModelCreating(modelBuilder);
        }
    }
}