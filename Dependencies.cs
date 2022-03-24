using System;
using System.Net.Http;
using Inchcape.Akeneo.Connector;
using Inchcape.Akeneo.Connector.Connectors;
using Inchcape.Akeneo.Connector.RequestHandlers;
using Polly;
using Refit;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Dependencies
    {
        public static IServiceCollection AddAkeneoConnectors(this IServiceCollection services, Action<AkeneoSettings> actionSetup)
        {
            var settings = new AkeneoSettings();

            actionSetup.Invoke(settings);

            return services.AddAkeneoConnectors(settings);
        }

        public static IServiceCollection AddAkeneoConnectors(this IServiceCollection services, AkeneoSettings settings)
        {
            services.AddSingleton<AkeneoSettings>(settings);
            services.AddTransient<BasicAuthenticationHandler>();
            services.AddTransient<TokenAuthenticationHandler>();
            
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());

            services
                .AddRefitClient<IAkeneoAuthTokenConnector>(_ => refitSettings)
                .AddHttpMessageHandler<BasicAuthenticationHandler>()
                .AddTransientHttpErrorPolicy(RetryPolicy)
                .ConfigureHttpClient(SetupClient(settings));

            services
                .AddRefitClient<IAkeneoProductsConnector>(_ => refitSettings)
                .AddHttpMessageHandler<TokenAuthenticationHandler>()
                .AddTransientHttpErrorPolicy(RetryPolicy)
                .ConfigureHttpClient(SetupClient(settings));

            services
                .AddRefitClient<IAkeneoRefEntitiesConnector>(_ => refitSettings)
                .AddHttpMessageHandler<TokenAuthenticationHandler>()
                .AddTransientHttpErrorPolicy(RetryPolicy)
                .ConfigureHttpClient(SetupClient(settings));

            services
                .AddRefitClient<IAkeneoAssetsManagerConnector>(_ => refitSettings)
                .AddHttpMessageHandler<TokenAuthenticationHandler>()
                .AddTransientHttpErrorPolicy(RetryPolicy)
                .ConfigureHttpClient(SetupClient(settings));

            return services;
        }

        public static IAsyncPolicy<HttpResponseMessage> RetryPolicy(PolicyBuilder<HttpResponseMessage> policyBuilder)
        {
            var retryPolicy = policyBuilder.WaitAndRetryAsync(3, retryCount => TimeSpan.FromMilliseconds(600));

            return retryPolicy;
        }

        private static Action<HttpClient> SetupClient(AkeneoSettings settings)
        {
            return client =>
            {
                client.BaseAddress = settings.BaseUrl;
            };
        }

    }
}
