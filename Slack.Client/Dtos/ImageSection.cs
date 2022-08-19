using Slack.Client.Dtos.BaseTypes;
using Slack.Client.Dtos.Enums;

namespace Slack.Client.Dtos;

public class ImageSection : Section
{
    public ImageSection(string title, string imgUrl, string altText = "")
    {
        Type = "image";
        Title = new() { Type = FieldType.plain_text, Text = title };
        ImageUrl = imgUrl;
        AlternativeText = altText;
    }
}
