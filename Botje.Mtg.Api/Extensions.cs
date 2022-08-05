namespace Botje.Mtg.Api;

public static class Extensions
{
    public static IConfigurationBuilder SetupSecrets(this IConfigurationBuilder configurationManager)
    {
        const string wellKnownSecretDirectory = "/run/secrets/";

        configurationManager.AddKeyPerFile(wellKnownSecretDirectory);

        return configurationManager;
    }
}
