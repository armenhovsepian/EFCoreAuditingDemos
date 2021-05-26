using CustomAuditingDemo.Data;
using CustomAuditingDemo.Models;
using System.Threading.Tasks;

namespace CustomAuditingDemo
{
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
