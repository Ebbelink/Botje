using System.Text.Json.Serialization;

namespace Botje.Mtg.Api.Dtos.Slack.Events;

public class AppHomeOpened
{
    public string Type { get; set; }
    public string User { get; set; }
    public string Channel { get; set; }
    [JsonPropertyName("event_ts")]
    public string EventTimestamp { get; set; }
    public string Tab { get; set; }
    public View View { get; set; }
}

public class View
{
    public string Id { get; set; }
    public string Team_id { get; set; }
    public string Type { get; set; }
    public List<object> Blocks { get; set; }
    [JsonPropertyName("private_metadata")]
    public string PrivateMetadata { get; set; }
    [JsonPropertyName("callback_id")]
    public string CallbackId { get; set; }
    //public State state { get; set; }
    public string Hash { get; set; }
    [JsonPropertyName("clear_on_close")]
    public bool ClearOnClose { get; set; }
    [JsonPropertyName("notify_on_close")]
    public bool NotifyOnClose { get; set; }
    [JsonPropertyName("root_view_id")]
    public string RootViewId { get; set; }
    [JsonPropertyName("app_id")]
    public string AppId { get; set; }
    [JsonPropertyName("external_id")]
    public string ExternalId { get; set; }
    [JsonPropertyName("app_installed_team_id")]
    public string AppInstalledTeamId { get; set; }
    [JsonPropertyName("bot_id")]
    public string BotId { get; set; }
}

