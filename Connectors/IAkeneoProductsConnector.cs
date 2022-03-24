using System;
using System.Threading.Tasks;
using Inchcape.Akeneo.Connector.Responses;
using Refit;

namespace Inchcape.Akeneo.Connector.Connectors
{
    public interface IAkeneoProductsConnector
    {
        [Get("/api/rest/v1/products")]
        Task<PimProductResponse> GetProductsAsync();

        [Get("/api/rest/v1/products/{code}")]
        Task<PimProductResponse> GetProductAsync([AliasAs("code")] string code);

        [Get("/api/rest/v1/product-models/{code}")]
        Task<PimProductResponse> GetModelAsync([AliasAs("code")] string code);

        [Get("/api/rest/v1/products")]
        [QueryUriFormat(UriFormat.Unescaped)]
        Task<AkeneoProductSearchResponse> SearchAsync([AliasAs("search")] string search);
    }
}
