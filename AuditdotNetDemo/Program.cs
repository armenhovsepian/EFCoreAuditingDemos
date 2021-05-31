using Audit.NET.PostgreSql;
using Audit.PostgreSql.Providers;
using AuditdotNetDemo.Data;
using System.Collections.Generic;

namespace AuditdotNetDemo
{
    /// <summary>
    /// References:
    /// 
    /// https://github.com/thepirat000/Audit.NET/tree/master/src/Audit.NET.PostgreSql
    /// https://www.puresourcecode.com/dotnet/net-core/audit-with-entity-framework-core/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 
            Audit.Core.Configuration.DataProvider = new PostgreSqlDataProvider()
            {
                ConnectionString = "Host=127.0.0.1;Database=AuditdotNetDemoDB;Username=postgres;Password=Zevit2019!",
                TableName = "event",
                IdColumnName = "id",
                DataColumnName = "data",
                DataType = "JSONB",
                LastUpdatedDateColumnName = "updated_date",
                CustomColumns = new List<CustomColumn>()
                    {
                        new CustomColumn("event_type", ev => ev.EventType),
                        new CustomColumn("username", ev => ev.Environment.UserName),
                        new CustomColumn("namespace", ev => ev.Target.Type)
                    }
            };

            /*
            Audit.Core.Configuration.Setup()
                .UseEntityFramework(ef => ef.AuditTypeExplicitMapper(m => m
                    //.Map<ValueEntity, Audit_ValueEntity>()
                    //.Map<ContactEntity, Audit_ContactEntity>()
                    // add more .Map<TableEntity, Audit_TableEntity>()
                    .AuditEntityAction((evt, entry, auditEntity) =>
                    {
                        //auditEntity.AuditDate = DateTime.UtcNow;
                        //auditEntity.UserName = evt.Environment.UserName;
                        //auditEntity.AuditAction = entry.Action;
                    })));
            */

            using (var ctx = new AppDbContext())
            {

                //ctx.AddAuditCustomField("UserName", "AAA");

                //var p = new Product
                //{
                //    Id = new Random().Next(0, Int32.MaxValue),
                //    Name = "P2",
                //    Description = "D2"
                //};
                //ctx.Products.Add(p);

                var p = ctx.Products.Find(1547140054);
                p.Name = "XXX";
                ctx.Products.Update(p);
                ctx.SaveChanges();
            }



        }
    }
}
