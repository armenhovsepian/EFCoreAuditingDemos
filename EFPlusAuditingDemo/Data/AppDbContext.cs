using EFPlusAuditingDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace EFPlusAuditingDemo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        //public DbSet<CustomAuditEntry> AuditEntries { get; set; }
        //public DbSet<CustomAuditEntryProperty> AuditEntryProperties { get; set; }
        public DbSet<AuditEntry> AuditEntries { get; set; }
        public DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }


        static AppDbContext()
        {
            // Global options
            // https://entityframework-plus.net/ef6-audit-autosave
            AuditManager.DefaultConfiguration.AutoSavePreAction = (context, audit) =>
               // ADD "Where(x => x.AuditEntryID == 0)" to allow multiple SaveChanges with same Audit
               (context as AppDbContext).AuditEntries.AddRange(audit.Entries);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=EFPlusAuditingDemoDB;Username=postgres;Password=Abc1234");
        }

        public override int SaveChanges()
        {
            var audit = new Audit();
            audit.PreSaveChanges(this);
            var rowAffecteds = base.SaveChanges();
            audit.PostSaveChanges();

            if (audit.Configuration.AutoSavePreAction != null)
            {
                audit.Configuration.AutoSavePreAction(this, audit);
                base.SaveChanges();
            }

            return rowAffecteds;
        }

        //public override Task<int> SaveChangesAsync()
        //{
        //	return SaveChangesAsync(CancellationToken.None);
        //}

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var audit = new Audit();
            audit.PreSaveChanges(this);
            var rowAffecteds = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            audit.PostSaveChanges();

            if (audit.Configuration.AutoSavePreAction != null)
            {
                audit.Configuration.AutoSavePreAction(this, audit);
                await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }

            return rowAffecteds;
        }

    }
}
