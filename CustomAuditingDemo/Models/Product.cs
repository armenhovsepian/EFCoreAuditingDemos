using CustomAuditingDemo.Attributes;
using CustomAuditingDemo.Data;

namespace CustomAuditingDemo.Models
{
    public class Product : IAuditor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [AuditIgnore]
        public string Description { get; set; }
    }
}
