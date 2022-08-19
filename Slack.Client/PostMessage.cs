using Slack.Client.Dtos.BaseTypes;
using System.Text.Json.Serialization;

namespace Slack.Client;

public class PostMessage
{
    public PostMessage(string channel,
                       string? threadTimestamp = null,
                       ICollection<Section>? blocks = null,
                       string? text = null, 
                       bool? replyBroadcast = null)
    {
        if (blocks == null && string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException($"Either {nameof(blocks)} or {nameof(text)} must be present.");
        }

        Channel = channel;
        ThreadTimestamp = threadTimestamp;
        Blocks = blocks;
        Text = text;
        ReplyBroadcast = replyBroadcast;
    }

    //REQUIRED
    [JsonPropertyName("channel")]
    public string Channel { get; protected set; }
    
    //OPTIONAL
    [JsonPropertyName("thread_ts")]
    public string? ThreadTimestamp { get; protected set; }
        
    [JsonPropertyName("blocks")]
    public ICollection<Section>? Blocks { get; protected set; }
    
    [JsonPropertyName("text")]
    public string? Text { get; protected set; }
    
    [JsonPropertyName("reply_broadcast")]
    public bool? ReplyBroadcast { get; protected set; }
}
