using System;

namespace Inchcape.Akeneo.Connector.Attributes
{
    
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PimPropertyPriceAttribute : Attribute
    {
        public string Field { get; }
        public string Currency { get; set; } = "AUD";

        public PimPropertyPriceAttribute(string field)
        {
            Field = field;
        }
    }
}