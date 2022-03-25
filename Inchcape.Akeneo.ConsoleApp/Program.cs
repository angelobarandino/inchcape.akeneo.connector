using Inchcape.Akeneo.Connector.Models;
using Refit;

var host = App.CreateHostBuilder(args).Build();

var productConnector = host.Services.GetRequiredService<IAkeneoProductModelsConnector>();

try
{
    var product = await productConnector.GetAsync(new QueryParams(withCount: true)
    {
        Search = new SearchFilter()
            .Set("categories", "IN", new[] { "AustraliaSubaruVehicle" }, locale: "en_AU")
            .Set("parent", "EMPTY", null)
            .ToString(),
    });

    Console.WriteLine(product.Items.Count);
}
catch (ApiException e)
{
    Console.WriteLine(e.Content);
}