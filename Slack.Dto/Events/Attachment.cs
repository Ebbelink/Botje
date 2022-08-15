using System.Text.Json.Serialization;

namespace Slack.Dto.Events;

public class Attachment
{
    [JsonConstructor]
    public Attachment(
        string fromUrl,
        string thumbUrl,
        int thumbWidth,
        int thumbHeight,
        string videoHtml,
        int videoHtmlWidth,
        int videoHtmlHeight,
        string serviceIcon,
        int id,
        string originalUrl,
        string fallback,
        string title,
        string titleLink,
        string authorName,
        string authorLink,
        string serviceName,
        string serviceUrl
    )
    {
        FromUrl = fromUrl;
        ThumbUrl = thumbUrl;
        ThumbWidth = thumbWidth;
        ThumbHeight = thumbHeight;
        VideoHtml = videoHtml;
        VideoHtmlWidth = videoHtmlWidth;
        VideoHtmlHeight = videoHtmlHeight;
        ServiceIcon = serviceIcon;
        Id = id;
        OriginalUrl = originalUrl;
        Fallback = fallback;
        Title = title;
        TitleLink = titleLink;
        AuthorName = authorName;
        AuthorLink = authorLink;
        ServiceName = serviceName;
        ServiceUrl = serviceUrl;
    }

    [JsonPropertyName("from_url")]
    public string FromUrl { get; init; }

    [JsonPropertyName("thumb_url")]
    public string ThumbUrl { get; init; }

    [JsonPropertyName("thumb_width")]
    public int ThumbWidth { get; init; }

    [JsonPropertyName("thumb_height")]
    public int ThumbHeight { get; init; }

    [JsonPropertyName("video_html")]
    public string VideoHtml { get; init; }

    [JsonPropertyName("video_html_width")]
    public int VideoHtmlWidth { get; init; }

    [JsonPropertyName("video_html_height")]
    public int VideoHtmlHeight { get; init; }

    [JsonPropertyName("service_icon")]
    public string ServiceIcon { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("original_url")]
    public string OriginalUrl { get; init; }

    [JsonPropertyName("fallback")]
    public string Fallback { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; }

    [JsonPropertyName("title_link")]
    public string TitleLink { get; init; }

    [JsonPropertyName("author_name")]
    public string AuthorName { get; init; }

    [JsonPropertyName("author_link")]
    public string AuthorLink { get; init; }

    [JsonPropertyName("service_name")]
    public string ServiceName { get; init; }

    [JsonPropertyName("service_url")]
    public string ServiceUrl { get; init; }
}