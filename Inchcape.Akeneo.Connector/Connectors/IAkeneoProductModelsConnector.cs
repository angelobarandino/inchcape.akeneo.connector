using System;
using System.Threading.Tasks;
using Inchcape.Akeneo.Connector.Models;
using Inchcape.Akeneo.Connector.Responses;
using Refit;

namespace Inchcape.Akeneo.Connector.Connectors
{
    public interface IAkeneoProductModelsConnector
    {
        [Get("/api/rest/v1/product-models")]
        [QueryUriFormat(UriFormat.Unescaped)]
        Task<ProductsResponse> GetAsync(QueryParams @params = null);
        
        [Get("/api/rest/v1/product-models/{code}")]
        Task<ProductResponse> GetAsync([AliasAs("code")] string code);
        
        [Post("/api/rest/v1/product-models")]
        Task<ProductResponse> CreateAsync([Body] object data);
        
        [Patch("/api/rest/v1/product-models/{code}")]
        Task<ProductResponse> UpdateAsync([AliasAs("code")] string code, [Body] object data);
        
        [Delete("/api/rest/v1/product-models/{code}")]
        Task<ProductResponse> DeleteAsync([AliasAs("code")] string code);
    }
}