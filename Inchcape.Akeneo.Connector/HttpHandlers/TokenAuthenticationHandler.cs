using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Inchcape.Akeneo.Connector.Connectors;

namespace Inchcape.Akeneo.Connector.HttpHandlers
{
    public class TokenAuthenticationHandler : DelegatingHandler
    {
        private readonly IAkeneoAuthTokenConnector _tokenConnector;

        public TokenAuthenticationHandler(IAkeneoAuthTokenConnector tokenProvider)
        {
            _tokenConnector = tokenProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await _tokenConnector.GetTokenAsync();

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", response.AccessToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
