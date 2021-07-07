using System;

namespace EFCoreAuditingDemo.Models
{
    public class Audit
    {
        public Guid Id { get; set; }
        public string TableName { get; set; }
        public string StateName { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }

        public string ModifiedBy { get; set; }
        public DateTime DateTime { get; set; }
    }
}
