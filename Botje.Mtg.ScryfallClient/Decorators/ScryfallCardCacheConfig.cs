namespace Botje.Mtg.ScryfallClient.Decorators;

internal class ScryfallCardCacheConfig
{
    public string CardCachePath { get; }

    public ScryfallCardCacheConfig(string cardCachePath)
    {
        CardCachePath = cardCachePath;
    }
}
