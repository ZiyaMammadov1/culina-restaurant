using AuthService.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AuthService.Infrastructure
{
    public class CulinaDbContext : DbContext
    {
        public CulinaDbContext(DbContextOptions<CulinaDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
