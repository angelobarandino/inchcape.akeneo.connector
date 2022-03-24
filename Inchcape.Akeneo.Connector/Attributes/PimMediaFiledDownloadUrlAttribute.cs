using System;

namespace Inchcape.Akeneo.Connector.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PimMediaFiledDownloadUrlAttribute : Attribute
    {
        public string Field { get; }

        public PimMediaFiledDownloadUrlAttribute(string field)
        {
            Field = field;
        }
    }
}