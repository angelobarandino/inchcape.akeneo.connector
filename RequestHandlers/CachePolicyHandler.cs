using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Polly;
using Polly.Registry;

namespace Inchcape.Akeneo.Connector.RequestHandlers
{
    public class CachePolicyHandler : DelegatingHandler
    {
        public const string CacheKey = "AkeneoCachePolicy";
        
        private readonly IReadOnlyPolicyRegistry<string> _policyRegistry;
        public CachePolicyHandler(IReadOnlyPolicyRegistry<string> policyRegistry)
        {
            _policyRegistry = policyRegistry;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var policy = _policyRegistry.Get<IAsyncPolicy<HttpResponseMessage>>(CacheKey);

            var context = new Context(request.RequestUri.ToString());

            return await policy.ExecuteAsync(async c => await base.SendAsync(request, cancellationToken), context);
        }
    }
}