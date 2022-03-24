using System;

namespace Inchcape.Akeneo.Connector.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PimAssociationProductAttribute : Attribute
    {
        public string Name { get; }

        public PimAssociationProductAttribute(string name)
        {
            Name = name;
        }
    }
}