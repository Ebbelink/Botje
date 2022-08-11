using System.Text.Json.Serialization;

namespace Slack.Dto;

public class Authorization
{
    [JsonConstructor]
    public Authorization(
        string enterpriseId,
        string teamId,
        string userId,
        bool isBot,
        bool isEnterpriseInstall
    )
    {
        EnterpriseId = enterpriseId;
        TeamId = teamId;
        UserId = userId;
        IsBot = isBot;
        IsEnterpriseInstall = isEnterpriseInstall;
    }

    [JsonPropertyName("enterprise_id")]
    public string EnterpriseId { get; init; }

    [JsonPropertyName("team_id")]
    public string TeamId { get; init; }

    [JsonPropertyName("user_id")]
    public string UserId { get; init; }

    [JsonPropertyName("is_bot")]
    public bool IsBot { get; init; }

    [JsonPropertyName("is_enterprise_install")]
    public bool IsEnterpriseInstall { get; init; }
}