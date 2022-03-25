using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Inchcape.Akeneo.Connector.Connectors;

namespace Inchcape.Akeneo.Connector.HttpHandlers
{
    public class TokenAuthenticationHandler : DelegatingHandler
    {
        private readonly AkeneoSettings _settings;
        private readonly IServiceProvider _serviceProvider;

        public TokenAuthenticationHandler(AkeneoSettings settings, IServiceProvider serviceProvider)
        {
            _settings = settings;
            _serviceProvider = serviceProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await _settings.AuthorizationToken(_serviceProvider);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
