using System;
using System.Net.Http;
using System.Threading.Tasks;
using Inchcape.Akeneo.Connector;
using Inchcape.Akeneo.Connector.Connectors;
using Inchcape.Akeneo.Connector.HttpHandlers;
using Inchcape.Akeneo.Connector.Utils.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
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
            var serializer = new NewtonsoftJsonContentSerializer(
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = { new StringEnumConverter() },
                }
            );
            
            var refitSettings = new RefitSettings(serializer);

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
                .AddRefitClient<IAkeneoProductModelsConnector>(_ => refitSettings)
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

            services.AddSingleton<AkeneoSettings>(settings);
            services.AddTransient<BasicAuthenticationHandler>();
            services.AddTransient<TokenAuthenticationHandler>();
            services.AddTransient<MessageLoggingHandler>();

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
