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
        Task<ProductResponse> GetAsync([AliasAs("code")] string code);

        [Get("/api/rest/v1/products")]
        [QueryUriFormat(UriFormat.Unescaped)]
        Task<ProductsResponse> GetAsync(QueryParams @params = null);

        [Post("/api/rest/v1/products")]
        Task CreateAsync([Body] object product);
        
        [Patch("/api/rest/v1/products/{code}")]
        Task UpdateAsync([AliasAs("code")] string code, [Body] object product);
        
        [Delete("/api/rest/v1/products/{code}")]
        Task DeleteAsync([AliasAs("code")] string code);
    }
}
