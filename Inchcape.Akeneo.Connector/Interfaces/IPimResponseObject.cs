using System;

namespace Inchcape.Akeneo.Connector.Interfaces
{
    public interface IPimResponseObject : IPimCodeIdentifier
    {
        string Family { get; }
        string Parent { get; }
        bool Enabled { get; }
        string[] Categories { get; }
        string[] Groups { get; }
        DateTime Created { get; }
        DateTime Updated { get; }
    }
}