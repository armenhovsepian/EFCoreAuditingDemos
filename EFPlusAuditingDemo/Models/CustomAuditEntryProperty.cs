using Z.EntityFramework.Plus;

namespace EFPlusAuditingDemo.Models
{
    public class CustomAuditEntryProperty : AuditEntryProperty
    {
        public string CustomField { get; set; }
    }
}
