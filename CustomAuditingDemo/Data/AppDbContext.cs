using CustomAuditingDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomAuditingDemo.Data
{
    public class AppDbContext : CustomAuditDbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=EFAuditTrailDB;Username=postgres;Password=Abc1234");
        }
    }
}
