using EFPlusAuditingDemo.Data;

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

            using (var ctx = new AppDbContext())
            {
                //var p = new Product
                //{
                //    Id = new Random().Next(0, Int32.MaxValue),
                //    Name = "P2",
                //    Description = "D2"
                //};
                //ctx.Products.Add(p);

                var p = ctx.Products.Find(10);
                p.Name = "XXX";

                ctx.Products.Update(p);
                ctx.SaveChanges();
            }
        }
    }
}
