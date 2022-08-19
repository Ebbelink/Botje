using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slack.Client.Dtos.BaseTypes;
using Slack.Client.Dtos.Enums;

namespace Slack.Client.Dtos;

public class Button : Accessory
{
    public Button(string buttonText, string linkUrl)
        : this(buttonText, linkUrl, null, null)
    {
    }

    public Button(string buttonText, string linkUrl, string? buttonValue, string? buttonActionId)
    {
        Type = FieldType.button;
        Text = new()
        {
            Type = FieldType.plain_text,
            Text = buttonText
        };
        Url = linkUrl;
        Value = buttonValue;
        ActionId = buttonActionId;
    }
}
