using System.Text.RegularExpressions;

namespace Botje.Mtg.ScryfallClient
{
    internal static class CardHelper
    {
        public static string RemoveNonAlphabeticalCharactersFromString(string input) 
        {
            Regex weirdCharRegex = new Regex("[!@#$%^&*(),./;'\\[\\]\\\\\\-=<>?:\"{}|_+ ]");
            return weirdCharRegex.Replace(input, string.Empty);
        }
    }
}
