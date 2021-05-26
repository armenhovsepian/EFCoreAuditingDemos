using Z.EntityFramework.Plus;

namespace EFPlusAuditingDemo.Models
{
    class CustomAuditEntryProperty : AuditEntryProperty
    {
        public string CustomField { get; set; }
    }
}
