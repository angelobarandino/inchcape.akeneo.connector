using System.Threading.Tasks;
using Inchcape.Akeneo.Connector.Models;
using Inchcape.Akeneo.Connector.Responses;
using Refit;

namespace Inchcape.Akeneo.Connector.Connectors
{
    public interface IAkeneoRefEntitiesConnector
    {
        [Get("/api/rest/v1/reference-entities/{reference_entity_code}/records")]
        Task<ReferenceEntityResponse> GetRecordsAsync([AliasAs("reference_entity_code")] string referenceEntityCode, FilterParams filters = null);

        [Get("/api/rest/v1/reference-entities/{reference_entity_code}/records/{code}")]
        Task<ReferenceEntityRecordResponse> GetRecordsAsync([AliasAs("reference_entity_code")] string referenceEntityCode, [AliasAs("code")] string code);
    }
}
