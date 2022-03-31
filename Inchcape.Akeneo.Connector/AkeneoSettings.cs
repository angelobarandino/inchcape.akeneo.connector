using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;

namespace Inchcape.Akeneo.Connector
{
    public class AkeneoSettings
    {
        public Uri BaseUrl { get; set; }
        public string ClientId { get; set; }
        public string SecretKey { get; set; }

        public int RetryCount { get; set; } = 2;
        public int RetryDelay { get; set; } = 2;
        
        public RefitSettings RefitSettings { get; set; }

        public Func<IServiceProvider, Task<string>> AuthorizationToken { get; set; }

        public static RefitSettings DefaultRefitSettings()
        {
            var serializer = new NewtonsoftJsonContentSerializer(
                new JsonSerializerSettings
                {
                    Converters = { new StringEnumConverter() },
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                }
            );
            
            var refitSettings = new RefitSettings(serializer);

            return refitSettings;
        }
    }
}
