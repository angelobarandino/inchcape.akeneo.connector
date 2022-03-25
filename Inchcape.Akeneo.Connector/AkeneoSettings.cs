using System;
using Inchcape.Akeneo.Connector.Models;
using Newtonsoft.Json;

namespace Inchcape.Akeneo.Connector
{
    public class AkeneoSettings
    {
        public Uri BaseUrl { get; set; }
        public string ClientId { get; set; }
        public string SecretKey { get; set; }

        public UserCredentials User { get; set; }

        public int RetryCount { get; set; } = 2;
        public int RetryDelay { get; set; } = 2;
    }
}
