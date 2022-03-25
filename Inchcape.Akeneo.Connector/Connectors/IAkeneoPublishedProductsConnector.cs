using System;
using System.Threading.Tasks;
using Inchcape.Akeneo.Connector.Models;
using Inchcape.Akeneo.Connector.Responses;
using Refit;

namespace Inchcape.Akeneo.Connector.Connectors
{
    public interface IAkeneoPublishedProductsConnector
    {
        [Get("/api/rest/v1/published-products")]
        [QueryUriFormat(UriFormat.Unescaped)]
        Task<ProductsResponse> GetAsync(QueryParams @params = null);
        
        [Get("/api/rest/v1/published-products/{code}")]
        Task<ProductResponse> GetAsync([AliasAs("code")] string code);
    }
}