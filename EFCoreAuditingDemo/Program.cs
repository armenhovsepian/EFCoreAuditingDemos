﻿using Common.Models;
using EFCoreAuditingDemo.Data;
using EFCoreAuditingDemo.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreAuditingDemo
{
    /// <summary>
    /// https://github.com/OKTAYKIR/EFCoreAuditing/
    /// </summary>
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateAsync();
            await UpdateAsync();
            await RemoveAsync();

            await GetAuditsAsync();

        }



        static async Task CreateAsync()
        {
            Console.WriteLine("Adding!");

            using var ctx = new AuditLogDbContext();
            var p = new Product
            {
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


        static async Task GetAuditsAsync()
        {
            Console.WriteLine("Get Audits!");

            using var ctx = new AuditLogDbContext();
            var audits = await ctx.Audits
                .Where(x => x.AuditType == Models.AuditType.Deleted)
                .ToListAsync();



            var d = audits.Select(x => new AuditDto(x)).ToList();
        }
    }
}
