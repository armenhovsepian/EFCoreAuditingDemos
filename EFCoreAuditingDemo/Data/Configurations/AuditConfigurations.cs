using EFCoreAuditingDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreAuditingDemo.Data.Configurations
{
    /// <summary>
    /// https://www.npgsql.org/efcore/mapping/json.html
    /// </summary>
    public class AuditConfigurations : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.Property(x => x.KeyValues).HasColumnType("jsonb");
            builder.Property(x => x.OldValues).HasColumnType("jsonb");
            builder.Property(x => x.NewValues).HasColumnType("jsonb");

        }
    }
}
