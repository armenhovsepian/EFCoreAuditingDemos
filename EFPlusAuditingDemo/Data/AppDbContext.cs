using EFPlusAuditingDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Z.EntityFramework.Plus;

namespace EFPlusAuditingDemo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomAuditEntry> AuditEntries { get; set; }
        public DbSet<CustomAuditEntryProperty> AuditEntryProperties { get; set; }


        static AppDbContext()
        {
            // Global options
            // https://entityframework-plus.net/ef6-audit-autosave
            AuditManager.DefaultConfiguration.AutoSavePreAction = (context, audit) =>
               // ADD "Where(x => x.AuditEntryID == 0)" to allow multiple SaveChanges with same Audit
               (context as AppDbContext).AuditEntries.AddRange(audit.Entries.Cast<CustomAuditEntry>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=EFPlusAuditingDemoDB;Username=postgres;Password=Abc1234");
        }

        public override int SaveChanges()
        {
            var audit = new Audit();
            audit.CreatedBy = "rmn.hovsepian@live.com";

            // https://entityframework-plus.net/ef6-audit-customization
            audit.Configuration.AuditEntryFactory = args =>
                new CustomAuditEntry() { IpAdress = "127.0.0.1" };

            // Access to all auditing information
            //var entries = audit.Entries;
            //foreach (var entry in entries)
            //{
            //    foreach (var property in entry.Properties)
            //    {
            //    }
            //}

            audit.Configuration.Exclude(x => true); // Exclude ALL
            audit.Configuration.Include<IAuditable>();

            audit.PreSaveChanges(this);
            var rowAffecteds = base.SaveChanges();
            audit.PostSaveChanges();

            //if (audit.Configuration.AutoSavePreAction != null)
            //{
            //    audit.Configuration.AutoSavePreAction(this, audit);
            //    base.SaveChanges();
            //}

            return rowAffecteds;
        }

    }
}
