using Inchcape.Akeneo.Connector.Utils.Converters;
using Newtonsoft.Json;
using Refit;

namespace Inchcape.Akeneo.Connector.Models
{
    public class QueryParams
    {
        public QueryParams() {}
        public QueryParams(bool withCompletenesses = false, bool withQualityScores = false, bool withCount = false)
        {
            if (withQualityScores) WithQualityScores = "true";
            if (withCompletenesses) WithCompletenesses = "true";
            if (withCount) WithCount = "true";
        }

        [AliasAs("locales")] public string Locales { get; set; }
        [AliasAs("scope")] public string Scope { get; set; }
        [AliasAs("channel")] public string Channel { get; set; }
        [AliasAs("search")] public string Search { get; set; }
        [AliasAs("page")] public int? Page { get; set; }
        [AliasAs("limit")] public int? Limit { get; set; }
        [AliasAs("with_quality_scores")] public string WithQualityScores { get; }
        [AliasAs("with_completenesses")] public string WithCompletenesses { get; }
        [AliasAs("with_count")] public string WithCount { get; }
    }
}