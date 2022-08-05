namespace Botje.Mtg.Api;

public static class Extensions
{
    public static IConfigurationBuilder SetupSecrets(this IConfigurationBuilder configurationManager)
    {
        const string wellKnownSecretsDirectory = "/run/secrets/";

        configurationManager.AddKeyPerFile(wellKnownSecretsDirectory);

        return configurationManager;
    }
}
