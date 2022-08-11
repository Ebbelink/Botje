using System.Text.Json.Serialization;

namespace Slack.Dto;

public class EventWrapper
{
    [JsonConstructor]
    public EventWrapper(
        string token,
        string teamId,
        string apiAppId,
        Event @event,
        string type,
        string eventId,
        int eventTime,
        List<Authorization> authorizations,
        bool isExtSharedChannel,
        string eventContext
    )
    {
        Token = token;
        TeamId = teamId;
        ApiAppId = apiAppId;
        Event = @event;
        Type = type;
        EventId = eventId;
        EventTime = eventTime;
        Authorizations = authorizations;
        IsExtSharedChannel = isExtSharedChannel;
        EventContext = eventContext;
    }

    [JsonPropertyName("token")]
    public string Token { get; init; }

    [JsonPropertyName("team_id")]
    public string TeamId { get; init; }

    [JsonPropertyName("api_app_id")]
    public string ApiAppId { get; init; }

    [JsonPropertyName("event")]
    public Event Event { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }

    [JsonPropertyName("event_id")]
    public string EventId { get; init; }

    [JsonPropertyName("event_time")]
    public int EventTime { get; init; }

    [JsonPropertyName("authorizations")]
    public List<Authorization> Authorizations { get; init; }

    [JsonPropertyName("is_ext_shared_channel")]
    public bool IsExtSharedChannel { get; init; }

    [JsonPropertyName("event_context")]
    public string EventContext { get; init; }
}