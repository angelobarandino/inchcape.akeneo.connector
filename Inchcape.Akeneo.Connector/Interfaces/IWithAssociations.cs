using Inchcape.Akeneo.Connector.Models;

namespace Inchcape.Akeneo.Connector.Interfaces
{
    public interface IWithAssociations 
    {
        AssociationsDictionary Associations { get; }
    }
}