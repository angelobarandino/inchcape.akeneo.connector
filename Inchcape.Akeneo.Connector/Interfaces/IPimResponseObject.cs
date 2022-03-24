using Inchcape.Akeneo.Connector.Models;

namespace Inchcape.Akeneo.Connector.Interfaces
{
    public interface IPimResponseObject : IPimCodeIdentifier
    {
        string Family { get; }
        string Parent { get; }
        bool Enabled { get; }
        
        public interface IWithAssociations : IPimResponseObject
        {
            AssociationsDictionary Associations { get; }
        }
    }
}