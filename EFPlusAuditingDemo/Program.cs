using EFPlusAuditingDemo.Data;
using EFPlusAuditingDemo.Models;
using System;
using System.Linq;

namespace EFPlusAuditingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Audit Customization: Globally
            //AuditManager.DefaultConfiguration
            //    .AuditEntryFactory = args =>
            //        new AuditEntry() { CreatedDate = DateTime.Now.AddHours(-5) };

            //AuditManager.DefaultConfiguration
            //    .AuditEntryFactory = args =>
            //    new CustomAuditEntry() { IpAdress = "127.0.0.1" };

            //AuditManager.DefaultConfiguration
            //            .AuditEntryPropertyFactory = args =>
            //                new CustomAuditEntryProperty() { CustomField = "value" };

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
