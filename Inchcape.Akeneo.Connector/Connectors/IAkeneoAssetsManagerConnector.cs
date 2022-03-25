using System.Threading.Tasks;
using Inchcape.Akeneo.Connector.Responses;
using Refit;

namespace Inchcape.Akeneo.Connector.Connectors
{
    public interface IAkeneoAssetsManagerConnector
    {
        [Get("/api/rest/v1/asset-families/{asset_family_code}/assets")]
        Task<AssetFamiliesResponse> GetAssetsAsync([AliasAs("asset_family_code")] string assetFamilyCode);
        
        [Get("/api/rest/v1/asset-families/{asset_family_code}/assets/{code}")]
        Task<AssetFamiliesResponse> GetAssetAsync([AliasAs("asset_family_code")] string assetFamilyCode, [AliasAs("code")] string code);
    }
}