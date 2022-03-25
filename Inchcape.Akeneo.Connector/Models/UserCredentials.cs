using Newtonsoft.Json;

namespace Inchcape.Akeneo.Connector.Models
{
    public class UserCredentials
    {
        [JsonProperty("grant_type")] public string GrantType { get; set; }
        [JsonProperty("username")] public string Username { get; set; }
        [JsonProperty("password")] public string Password { get; set; }
    }
}