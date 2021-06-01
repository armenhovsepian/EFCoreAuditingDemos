using System;

namespace CustomAuditingDemo.Models
{
    public class AuditTrail
    {
        public long Id { get; set; }
        public string Table { get; set; }
        public string Column { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Auditor { get; set; }
        /// <summary>
        /// AuditType/AuditAction: Inset/Update/Delete
        /// </summary>
        public string ChangeType { get; set; }
        public DateTime Date { get; set; }
    }
}
