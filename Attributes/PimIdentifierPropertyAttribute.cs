using System;

namespace Inchcape.Akeneo.Connector.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PimIdentifierPropertyAttribute : Attribute
    {
        public string Field { get; }
        
        public PimIdentifierPropertyAttribute(string field)
        {
            Field = field;
        }
    }
}