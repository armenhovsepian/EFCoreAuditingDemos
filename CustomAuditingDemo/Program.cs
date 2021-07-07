using Common.Models;
using CustomAuditingDemo.Data;
using System;
using System.Linq;

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
        static void Main(string[] args)
        {

            Create();
            Update();
            Remove();
        }


        static void Create()
        {
            Console.WriteLine("Adding!");

            using var ctx = new AppDbContext();
            var p = new Product
            {
                //Id = new Random().Next(0, Int32.MaxValue),
                Name = "P1",
                Description = "D1"
            };

            ctx.Products.Add(p);
            ctx.SaveChanges();
        }


        static void Update()
        {
            Console.WriteLine("Modifing!");

            using var ctx = new AppDbContext();
            var p = ctx.Products.First();
            p.Name = $"{p.Name} {DateTime.Now.Ticks}";

            ctx.Products.Update(p);
            ctx.SaveChanges();
        }


        static void Remove()
        {
            Console.WriteLine("Deleting!");

            using var ctx = new AppDbContext();
            var p = ctx.Products.First();

            ctx.Products.Remove(p);
            ctx.SaveChanges();
        }
    }
}
