﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Inchcape.Akeneo.Connector.RequestHandlers
{
    public class BasicAuthenticationHandler : DelegatingHandler
    {
        private readonly AkeneoSettings _settings;

        public BasicAuthenticationHandler(AkeneoSettings settings)
        {
            _settings = settings;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var content = JsonSerializer.Serialize(new
            {
                grant_type = "password",
                username = _settings.Username,
                password = _settings.Password
            });

            request.Content = new StringContent(content, Encoding.UTF8, "application/json");

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", GetBase64StringAuthenticationKey());

            return base.SendAsync(request, cancellationToken);
        }

        private string GetBase64StringAuthenticationKey()
        {
            var authKey = $"{_settings.ClientID}:{_settings.SecretKey}";

            var byteArr = Encoding.UTF8.GetBytes(authKey);

            return Convert.ToBase64String(byteArr);
        }
    }
}
