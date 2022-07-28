using Refit;

namespace Botje.Mtg.ScryfallClient.RefitClients.CardSearch;

public class CardsSearchQueryParameters
{
    public CardsSearchQueryParameters(
        string searchQuery,
        int page = 1,
        string unique = "cards",
        string order = "eur",
        string dir = "desc",
        string returnFormat = "json",
        bool includeExtras = false,
        bool? includeMultilingual = null,
        bool? includeVariations = null
        )
    {
        Query = searchQuery;
        Unique = unique;
        Order = order;
        Dir = dir;
        IncludeExtras = includeExtras;
        IncludeMultilingual = includeMultilingual;
        IncludeVariations = includeVariations;
        Page = page;
        ReturnFormat = returnFormat;
    }

    /// <summary>
    /// A fulltext search query. Make sure that your parameter is properly encoded. Maximum length: 1000 Unicode characters.
    /// </summary>
    [AliasAs("q")]
    public string Query { get; }

    /// <summary>
    /// The strategy for omitting similar cards. See below.
    /// </summary>
    [AliasAs("unique")]
    public string? Unique { get; }

    /// <summary>
    /// The method to sort returned cards. See below.
    /// </summary>
    [AliasAs("order")]
    public string? Order { get; }

    /// <summary>
    /// The direction to sort cards. See below.
    /// </summary>
    [AliasAs("dir")]
    public string? Dir { get; }

    /// <summary>
    /// If true, extra cards (tokens, planes, etc) will be included. Equivalent to adding include:extras to the fulltext search. Defaults to false.
    /// </summary>
    [AliasAs("include_extras")]
    public bool? IncludeExtras { get; }

    /// <summary>
    /// If true, cards in every language supported by Scryfall will be included. Defaults to false.
    /// </summary>
    [AliasAs("include_multilingual")]
    public bool? IncludeMultilingual { get; }

    /// <summary>
    /// If true, rare care variants will be included, like the Hairy Runesword. Defaults to false.
    /// </summary>
    [AliasAs("include_variations")]
    public bool? IncludeVariations { get; }

    /// <summary>
    /// The page number to return, default 1.
    /// </summary>
    [AliasAs("page")]
    public int? Page { get; }

    /// <summary>
    /// The data format to return: json or csv. Defaults to json.
    /// </summary>
    [AliasAs("format")]
    public string? ReturnFormat { get; }

    /// <summary>
    /// If true, the returned JSON will be prettified. Avoid using for production code.
    /// </summary>
    [AliasAs("pretty")]
    public bool? Prettify { get; } = null;
}
