using Microsoft.EntityFrameworkCore;
using ProyAppVangAPI.Core.Entities;
using ProyAppVangAPI.Infrastructure.Configurations;

namespace ProyAppVangAPI.Infrastructure
{
    public class ProyAppVangAPIDbContext : DbContext
    {
        public ProyAppVangAPIDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Lista> Lists;

        public DbSet<User> Users;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ListConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
