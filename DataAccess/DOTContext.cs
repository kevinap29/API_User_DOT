using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess
{
    public class DOTContext(DbContextOptions<DOTContext> options) : DbContext(options)
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<User_Sessions> User_Sessions { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
