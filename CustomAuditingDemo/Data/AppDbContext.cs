using CustomAuditingDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomAuditingDemo.Data
{
    public class AppDbContext : AuditingDbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
