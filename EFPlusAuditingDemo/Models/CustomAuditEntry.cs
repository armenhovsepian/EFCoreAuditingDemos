using Z.EntityFramework.Plus;

namespace EFPlusAuditingDemo.Models
{
    public class CustomAuditEntry : AuditEntry
    {
        public string IpAdress { get; set; }
    }
}
