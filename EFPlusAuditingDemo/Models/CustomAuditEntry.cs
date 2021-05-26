using Z.EntityFramework.Plus;

namespace EFPlusAuditingDemo.Models
{
    class CustomAuditEntry : AuditEntry
    {
        public string IpAdress { get; set; }
    }
}
