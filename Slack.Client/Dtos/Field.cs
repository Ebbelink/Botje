namespace Slack.Client.Dtos;

public class Field
{
    public string Text { get; set; }
    public FieldType Type { get; set; }
    public bool? Emoji { get; set; }
}