using System;

namespace CustomAuditingDemo.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AuditIgnore : Attribute
    {

    }
}
