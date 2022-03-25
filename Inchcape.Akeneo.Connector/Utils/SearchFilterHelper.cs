using Inchcape.Akeneo.Connector.Models;

namespace Inchcape.Akeneo.Connector
{
    public static class SearchFilterHelper
    {
        public static SearchFilter In(this SearchFilter searchFilter, string attribute, string[] value) => searchFilter.Set(attribute, "IN", value);
        public static SearchFilter NotIn(this SearchFilter searchFilter, string attribute, string[] value) => searchFilter.Set(attribute, "NOT IN", value);
        public static SearchFilter Equals(this SearchFilter searchFilter, string attribute, object value) => searchFilter.Set(attribute, "=", value);
        public static SearchFilter NotEquals(this SearchFilter searchFilter, string attribute, object value) => searchFilter.Set(attribute, "!=", value);
    }
}