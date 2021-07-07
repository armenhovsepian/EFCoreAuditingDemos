using System;

namespace Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AuditIgnore : Attribute
    {

    }
}
