namespace Botje.Mtg.Api.Dtos.Slack.Events;

public class UrlVerification
{
    public string Token { get; set; }
    public string Challenge { get; set; }
    public string Type { get; set; }
}
