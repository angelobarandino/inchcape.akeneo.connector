using System.Threading.Tasks;
using Inchcape.Akeneo.Connector.Models;
using Inchcape.Akeneo.Connector.Responses;
using Refit;

namespace Inchcape.Akeneo.Connector.Connectors
{
    public interface IAkeneoAuthTokenConnector
    {
        [Post("/api/oauth/v1/token")]
        Task<AuthTokenResponse> GetTokenAsync([Body] UserCredentials user);
    }
}
