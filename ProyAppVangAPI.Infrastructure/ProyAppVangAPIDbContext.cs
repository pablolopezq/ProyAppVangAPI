using Microsoft.EntityFrameworkCore;
using ProyAppVangAPI.Core.Entities;
using shoponline.Infrastructure.Configurations;

namespace ProyAppVangAPI.Infrastructure
{
    public class ProyAppVangAPIDbContext : DbContext
    {
        public ProyAppVangAPIDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Lista> Lists;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ListConfiguration());
        }
    }
}
