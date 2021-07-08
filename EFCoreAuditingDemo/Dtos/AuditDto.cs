using EFCoreAuditingDemo.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EFCoreAuditingDemo.Dtos
{
    public class AuditDto
    {
        public AuditDto(Audit audit)
        {
            ModifiedBy = audit.ModifiedBy;
            EntityName = audit.EntityName;
            AuditType = audit.AuditType;
            //StateName = audit.StateName;
            KeyValues = JsonConvert.DeserializeObject<Dictionary<string, object>>(audit.KeyValues);
            OldValues = audit.OldValues == null ? null : JsonConvert.DeserializeObject<Dictionary<string, object>>(audit.OldValues);
            NewValues = audit.NewValues == null ? null : JsonConvert.DeserializeObject<Dictionary<string, object>>(audit.NewValues);
        }

        public string ModifiedBy { get; set; }
        public string EntityName { get; set; }
        public AuditType AuditType { get; set; }
        //public string StateName { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
    }
}
