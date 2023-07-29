using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Activity> Activities { get; set; }
        public DbSet<User> Users { get;}
        public DbSet<Group> Groups{ get; set; }
        public DbSet<Company> Companies{ get; set; }
    }
}