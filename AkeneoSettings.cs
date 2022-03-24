using System;

namespace Inchcape.Akeneo.Connector
{
    public class AkeneoSettings
    {
        public Uri BaseUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientID { get; set; }
        public string SecretKey { get; set; }
    }
}
