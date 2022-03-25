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
                    settings.Username = "subaruauapi_8944";
                    settings.Password = "ca1b61f0d";
                    settings.ClientId = "5_274r0rig0kbooww0c0s0wkg4c0w80ksoowkg4k4gw000w444w4";
                    settings.SecretKey = "3rknbspzbk840gc4cow88swkw0o8cw80k0w4ccos04cw8gssg8";
                });
            })
            .ConfigureLogging((_, logging) => 
            {
                logging.ClearProviders();
                logging.AddSimpleConsole(options => options.IncludeScopes = true);
                logging.AddEventLog();
            });
}