using Slack.Client.Dtos.BaseTypes;
using System.Text.Json.Serialization;

namespace Slack.Client.Dtos;

public class MultiButtonSection : Section
{
    public MultiButtonSection()
    {
        Type = "actions";
        Elements = new List<Button>();
    }

    public void AddButton(string buttontext, string linkUrl)
    {
        AddButton(buttontext, linkUrl, null, null);
    }

    public void AddButton(string buttontext, string linkUrl, string? value, string? actionId)
    {
        Elements.Add(new Button(buttontext, linkUrl, value, actionId));
    }
}
