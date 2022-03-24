using System;

namespace Inchcape.Akeneo.Connector.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PimPropertyFieldAttribute : Attribute
    {
        public string Field { get; }

        public PimPropertyFieldAttribute(string field)
        {
            Field = field;
        }
    }
}
