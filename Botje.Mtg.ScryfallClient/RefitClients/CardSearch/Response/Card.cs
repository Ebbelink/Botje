using System.Text.Json.Serialization;

namespace Botje.Mtg.ScryfallClient.RefitClients.CardSearch.Response;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class Card
{
    private string? _queryableName = null;
    public string Name_Queryable
    {
        get
        {
            if (_queryableName == null)
                _queryableName = CardHelper.RemoveNonAlphabeticalCharactersFromString(Name);
            return _queryableName;
        }
    }


    [JsonPropertyName("object")]
    public string ObjectType { get; set; }
    public string Id { get; set; }
    [JsonPropertyName("oracle_id")]
    public string OracleId { get; set; }
    [JsonPropertyName("multiverse_ids")]
    public List<int> MultiverseIds { get; set; }
    [JsonPropertyName("tcgplayer_id")]
    public int TcgplayerId { get; set; }
    [JsonPropertyName("cardmarket_id")]
    public int CardmarketId { get; set; }
    public string Name { get; set; }
    public string Lang { get; set; }
    [JsonPropertyName("released_at")]
    public string ReleasedAt { get; set; }
    public string Uri { get; set; }
    [JsonPropertyName("scryfall_uri")]
    public string ScryfallUri { get; set; }
    public string Layout { get; set; }
    [JsonPropertyName("highres_image")]
    public bool HighresImage { get; set; }
    [JsonPropertyName("image_status")]
    public string ImageStatus { get; set; }
    [JsonPropertyName("image_uris")]
    public ImageUris ImageUris { get; set; }
    [JsonPropertyName("mana_cost")]
    public string ManaCost { get; set; }
    public double Cmc { get; set; }
    [JsonPropertyName("type_line")]
    public string TypeLine { get; set; }
    [JsonPropertyName("oracle_text")]
    public string OracleText { get; set; }
    public string Power { get; set; }
    public string Toughness { get; set; }
    public List<string> Colors { get; set; }
    [JsonPropertyName("color_identity")]
    public List<string> ColorIdentity { get; set; }
    public List<string> Keywords { get; set; }
    //public Legalities Legalities { get; set; }
    public Dictionary<string, string> Legalities { get; set; }
    public List<string> Games { get; set; }
    public bool Reserved { get; set; }
    public bool Foil { get; set; }
    public bool Nonfoil { get; set; }
    public List<string> Finishes { get; set; }
    public bool Oversized { get; set; }
    public bool Promo { get; set; }
    public bool Reprint { get; set; }
    public bool Variation { get; set; }
    [JsonPropertyName("set_id")]
    public string SetId { get; set; }
    public string Set { get; set; }
    [JsonPropertyName("set_name")]
    public string SetName { get; set; }
    [JsonPropertyName("set_type")]
    public string SetType { get; set; }
    [JsonPropertyName("set_uri")]
    public string SetUri { get; set; }
    [JsonPropertyName("set_search_uri")]
    public string SetSearchUri { get; set; }
    [JsonPropertyName("scryfall_set_uri")]
    public string ScryfallSetUri { get; set; }
    [JsonPropertyName("rulings_uri")]
    public string RulingsUri { get; set; }
    [JsonPropertyName("prints_search_uri")]
    public string PrintsSearchUri { get; set; }
    [JsonPropertyName("collector_number")]
    public string CollectorNumber { get; set; }
    public bool Digital { get; set; }
    public string Rarity { get; set; }
    [JsonPropertyName("card_back_id")]
    public string CardBackId { get; set; }
    public string Artist { get; set; }
    [JsonPropertyName("artist_ids")]
    public List<string> ArtistIds { get; set; }
    [JsonPropertyName("illustration_id")]
    public string IllustrationId { get; set; }
    [JsonPropertyName("border_color")]
    public string BorderColor { get; set; }
    public string Frame { get; set; }
    [JsonPropertyName("security_stamp")]
    public string SecurityStamp { get; set; }
    [JsonPropertyName("full_art")]
    public bool FullArt { get; set; }
    public bool Textless { get; set; }
    public bool Booster { get; set; }
    [JsonPropertyName("story_spotlight")]
    public bool StorySpotlight { get; set; }
    [JsonPropertyName("edhrec_rank")]
    public int EdhrecRank { get; set; }
    public Prices Prices { get; set; }
    [JsonPropertyName("related_uris")]
    public RelatedUris RelatedUris { get; set; }
    [JsonPropertyName("purchase_uris")]
    public PurchaseUris PurchaseUris { get; set; }
    [JsonPropertyName("flavor_text")]
    public string FlavorText { get; set; }
    [JsonPropertyName("penny_rank")]
    public int? PennyRank { get; set; }
    [JsonPropertyName("mtgo_id")]
    public int? MtgoId { get; set; }
    [JsonPropertyName("mtgo_foil_id")]
    public int? MtgoFoilId { get; set; }
    public string Watermark { get; set; }
    [JsonPropertyName("arena_id")]
    public int? ArenaId { get; set; }
    [JsonPropertyName("frame_effects")]
    public List<string> FrameEffects { get; set; }
    [JsonPropertyName("promo_types")]
    public List<string> PromoTypes { get; set; }
    public Preview Preview { get; set; }
    [JsonPropertyName("card_faces")]
    public List<CardFace> CardFaces { get; set; }
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.