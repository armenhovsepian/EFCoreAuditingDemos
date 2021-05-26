using EFPlusAuditingDemo.Models;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace EFPlusAuditingDemo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<AuditEntry> AuditEntries { get; set; }

        public DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }


        static AppDbContext()
        {
            AuditManager.DefaultConfiguration.AutoSavePreAction = (context, audit) =>
               // ADD "Where(x => x.AuditEntryID == 0)" to allow multiple SaveChanges with same Audit
               (context as AppDbContext).AuditEntries.AddRange(audit.Entries);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=EFPlusAuditingDemoDB;Username=postgres;Password=Zevit2019!");
        }


        public int Commit()
        {
            var audit = new Audit();
            audit.CreatedBy = "rmn.hovsepian@live.com";
            return this.SaveChanges(audit);
        }

    }
}
