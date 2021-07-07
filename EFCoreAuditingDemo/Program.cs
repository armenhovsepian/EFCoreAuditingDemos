using Common.Models;
using EFCoreAuditingDemo.Data;
using EFCoreAuditingDemo.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreAuditingDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateAsync();
            await UpdateAsync();
            await RemoveAsync();
        }



        static async Task CreateAsync()
        {
            Console.WriteLine("Adding!");

            using var ctx = new AuditLogDbContext();
            var p = new Product
            {
                //Id = 10,
                Name = "P1",
                Description = "D1"
            };

            await ctx.Products.AddAsync(p);
            await ctx.SaveChangesAsync();
        }


        static async Task UpdateAsync()
        {
            Console.WriteLine("Modifing!");

            using var ctx = new AuditLogDbContext();
            var p = ctx.Products.First();
            p.Name = $"{p.Name} {DateTime.Now.Ticks}";

            ctx.Products.Update(p);
            await ctx.SaveChangesAsync();
        }



        static async Task RemoveAsync()
        {
            Console.WriteLine("Deleting!");

            using var ctx = new AuditLogDbContext();
            var p = ctx.Products.First();

            ctx.Products.Remove(p);
            await ctx.SaveChangesAsync();
        }
    }
}
