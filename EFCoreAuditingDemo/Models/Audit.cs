using System;

namespace EFCoreAuditingDemo.Models
{
    public class Audit
    {
        public Guid Id { get; set; }
        public string EntityName { get; set; }
        public AuditType AuditType { get; set; }
        //public string StateName { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }

        public string ModifiedBy { get; set; }
        public DateTime DateTime { get; set; }
    }

    public enum AuditType
    {
        Detached = 0,
        Unchanged = 1,
        Deleted = 2,
        Modified = 3,
        Added = 4
    }
}
