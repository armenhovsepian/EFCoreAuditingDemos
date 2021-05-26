using CustomAuditingDemo.Data;
using CustomAuditingDemo.Models;
using System.Threading.Tasks;

namespace CustomAuditingDemo
{
    /// <summary>
    /// References:
    /// https://blog.victorleonardo.com/en/audit-trail-with-entity-framework-core/
    /// https://codewithmukesh.com/blog/audit-trail-implementation-in-aspnet-core/
    /// https://dejanstojanovic.net/aspnet/2018/november/tracking-data-changes-with-entity-framework-core/
    /// https://www.meziantou.net/entity-framework-core-history-audit-table.htm
    /// </summary>
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var ctx = new AppDbContext())
            {
                var p = new Product
                {
                    Id = 10,
                    Name = "P1",
                    Description = "D1"
                };

                await ctx.Products.AddAsync(p);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
