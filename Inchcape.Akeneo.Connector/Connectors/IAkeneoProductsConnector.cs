using System;
using System.Threading.Tasks;
using Inchcape.Akeneo.Connector.Models;
using Inchcape.Akeneo.Connector.Responses;
using Refit;

namespace Inchcape.Akeneo.Connector.Connectors
{
    public interface IAkeneoProductsConnector
    {
        [Get("/api/rest/v1/products/{code}")]
        Task<PimProductResponse> GetProductAsync([AliasAs("code")] string code);

        [Get("/api/rest/v1/products")]
        [QueryUriFormat(UriFormat.Unescaped)]
        Task<PimProductsResponse> GetProductsAsync(QueryParams @params = null);

        [Post("/api/rest/v1/products")]
        Task CreateProductAsync([Body] object product);
        
        [Patch("/api/rest/v1/products/{code}")]
        Task UpdateProductAsync([AliasAs("code")] string code, [Body] object product);
        
        [Delete("/api/rest/v1/products/{code}")]
        Task DeleteProductAsync([AliasAs("code")] string code);
        
        [Get("/api/rest/v1/product-models")]
        Task<PimProductsResponse> GetProductModelsAsync();
        
        [Get("/api/rest/v1/product-models")]
        [QueryUriFormat(UriFormat.Unescaped)]
        Task<PimProductsResponse> GetProductModelsAsync([AliasAs("search")] string search);
        
        [Get("/api/rest/v1/product-models/{code}")]
        Task<PimProductResponse> GetProductModelAsync([AliasAs("code")] string code);
    }
}
