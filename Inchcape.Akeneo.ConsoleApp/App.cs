using Inchcape.Akeneo.Connector.Models;

namespace Inchcape.Akeneo.ConsoleApp;

public class App
{
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddAkeneoConnectors(settings =>
                {
                    settings.BaseUrl = new Uri("https://inchcape-staging.cloud.akeneo.com/");
                    settings.ClientId = "5_274r0rig0kbooww0c0s0wkg4c0w80ksoowkg4k4gw000w444w4";
                    settings.SecretKey = "3rknbspzbk840gc4cow88swkw0o8cw80k0w4ccos04cw8gssg8";
                    
                    settings.AuthorizationToken = async sp =>
                    {
                        var tokenConnector = sp.GetRequiredService<IAkeneoAuthTokenConnector>();
                        var response = await tokenConnector.GetTokenAsync(new UserCredentials
                        {
                            GrantType = "password",
                            Username = "subaruauapi_8944",
                            Password = "ca1b61f0d",
                        });
                        
                        return response.AccessToken;
                    };
                });
            })
            .ConfigureLogging((_, logging) => 
            {
                logging.ClearProviders();
                logging.AddSimpleConsole(options => options.IncludeScopes = true);
                logging.AddEventLog();
            });
}