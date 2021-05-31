using Audit.EntityFramework;
using AuditdotNetDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AuditdotNetDemo.Data
{
    public class AppDbContext : AuditDbContext // : DbContext
    {
        //private static DbContextHelper _helper = new DbContextHelper();
        //private readonly IAuditDbContext _auditContext;

        public DbSet<Product> Products { get; set; }


        public AppDbContext()
        {
            //_auditContext = new DefaultAuditContext(this);
            //_helper.SetConfig(_auditContext);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=AuditdotNetDemoDB;Username=postgres;Password=Zevit2019!");
        }

        //public override int SaveChanges()
        //{
        //    return _helper.SaveChanges(_auditContext, () => base.SaveChanges());
        //}

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    return await _helper.SaveChangesAsync(_auditContext, () => base.SaveChangesAsync(cancellationToken));
        //}

    }
}
