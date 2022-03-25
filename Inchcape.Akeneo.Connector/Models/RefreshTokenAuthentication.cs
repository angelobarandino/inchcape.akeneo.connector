using Newtonsoft.Json;

namespace Inchcape.Akeneo.Connector.Models
{
    public class RefreshTokenAuthentication
    {
        [JsonProperty("grant_type")] 
        public string GrantType => "refresh_token";
        
        [JsonProperty("refresh_token")] 
        public string RefreshToken { get; set; }
    }
}