using CustomAuditingDemo.Attributes;
using CustomAuditingDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomAuditingDemo.Data
{
    public class CustomAuditDbContext : DbContext
    {
        public DbSet<AuditTrail> AuditTrails { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.Entries<IAuditable>().Where(e => !(e.Entity is AuditTrail) && e.State != EntityState.Detached && e.State != EntityState.Unchanged).ToList().ForEach(entry =>
            {
                Audit(entry);
            });

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=EFAuditTrailDB;Username=postgres;Password=Abc1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        private void Audit(EntityEntry entry)
        {
            foreach (var property in entry.Properties.Where(property => !Attribute.IsDefined(property.Metadata.PropertyInfo, typeof(AuditIgnore))))
            {
                var auditEntry = new AuditTrail
                {
                    Table = entry.Entity.GetType().Name, // e.Metadata.Relational().TableName, 
                    Column = property.Metadata.Name,
                    OldValue = property.OriginalValue.ToString(),
                    NewValue = property.CurrentValue.ToString(),
                    Auditor = "",
                    ChangeType = entry.State.ToString(),
                    Date = DateTime.Now
                };

                this.AuditTrails.Add(auditEntry);
            }
        }
    }
}
