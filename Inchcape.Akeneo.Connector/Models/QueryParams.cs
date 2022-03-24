using Refit;

namespace Inchcape.Akeneo.Connector.Models
{
    public class QueryParams
    {
        [AliasAs("locales")] public string Locales { get; set; }

        [AliasAs("scope")] public string Scope { get; set; }

        [AliasAs("channel")] public string Channel { get; set; }

        [AliasAs("search")] public string Search { get; set; }

        [AliasAs("page ")] public int Page { get; set; } = 1;

        [AliasAs("limit  ")] public int Limit { get; set; } = 100;

        [AliasAs("with_quality_scores ")] public bool WithQualityScores { get; set; }

        [AliasAs("with_completenesses  ")] public bool WithCompletenesses { get; set; }
    }
}