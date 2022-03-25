using System;
using System.Threading.Tasks;
using Inchcape.Akeneo.Connector.Models;
using Inchcape.Akeneo.Connector.Responses;
using Newtonsoft.Json;

namespace Inchcape.Akeneo.Connector
{
    public class AkeneoSettings
    {
        public Uri BaseUrl { get; set; }
        public string ClientId { get; set; }
        public string SecretKey { get; set; }

        public int RetryCount { get; set; } = 2;
        public int RetryDelay { get; set; } = 2;

        public Func<IServiceProvider, Task<string>> AuthorizationToken { get; set; }
    }
}
