using Newtonsoft.Json;

namespace Inchcape.Akeneo.Connector.Models
{
    public class UserPasswordAuthentication
    {
        [JsonProperty("grant_type")] 
        public string GrantType => "password";
        
        [JsonProperty("username")] 
        public string Username { get; set; }
        
        [JsonProperty("password")] 
        public string Password { get; set; }
    }
}