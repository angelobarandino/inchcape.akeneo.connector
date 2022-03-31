using System;
using System.Net.Http;
using Inchcape.Akeneo.Connector;
using Inchcape.Akeneo.Connector.Connectors;
using Inchcape.Akeneo.Connector.HttpHandlers;
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
            var refitSettings = settings.RefitSettings ?? AkeneoSettings.DefaultRefitSettings();

            services
                .AddRefitClient<IAkeneoAuthTokenConnector>(_ => refitSettings)
                .AddHttpMessageHandler<BasicAuthenticationHandler>()
                .AddTransientHttpErrorPolicy(RetryPolicy(settings))
                .ConfigureHttpClient(SetupClient(settings));
            
            services
                .AddRefitClient<IAkeneoPublishedProductsConnector>(_ => refitSettings)
                .AddHttpMessageHandler<TokenAuthenticationHandler>()
                .AddTransientHttpErrorPolicy(RetryPolicy(settings))
                .ConfigureHttpClient(SetupClient(settings));

            services
                .AddRefitClient<IAkeneoProductsConnector>(_ => refitSettings)
                .AddHttpMessageHandler<TokenAuthenticationHandler>()
                .AddTransientHttpErrorPolicy(RetryPolicy(settings))
                .ConfigureHttpClient(SetupClient(settings));

            services
                .AddRefitClient<IAkeneoProductModelsConnector>(_ => refitSettings)
                .AddHttpMessageHandler<TokenAuthenticationHandler>()
                .AddTransientHttpErrorPolicy(RetryPolicy(settings))
                .ConfigureHttpClient(SetupClient(settings));
            
            services
                .AddRefitClient<IAkeneoRefEntitiesConnector>(_ => refitSettings)
                .AddHttpMessageHandler<TokenAuthenticationHandler>()
                .AddTransientHttpErrorPolicy(RetryPolicy(settings))
                .ConfigureHttpClient(SetupClient(settings));

            services
                .AddRefitClient<IAkeneoAssetsManagerConnector>(_ => refitSettings)
                .AddHttpMessageHandler<TokenAuthenticationHandler>()
                .AddTransientHttpErrorPolicy(RetryPolicy(settings))
                .ConfigureHttpClient(SetupClient(settings));

            services.AddSingleton<AkeneoSettings>(settings);
            services.AddTransient<BasicAuthenticationHandler>();
            services.AddTransient<TokenAuthenticationHandler>();
            services.AddTransient<MessageLoggingHandler>();

            return services;
        }

        private static Func<PolicyBuilder<HttpResponseMessage>, IAsyncPolicy<HttpResponseMessage>> RetryPolicy(AkeneoSettings settings)
        {
            return policyBuilder =>
            {
                var retryPolicy = policyBuilder.WaitAndRetryAsync(settings.RetryCount, retryCount => TimeSpan.FromSeconds(Math.Pow(settings.RetryDelay, retryCount)));

                return retryPolicy;
            };
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
