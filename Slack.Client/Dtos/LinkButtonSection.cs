using Slack.Client.Dtos.BaseTypes;
using Slack.Client.Dtos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slack.Client.Dtos;

public class LinkButtonSection : Section
{
    public LinkButtonSection(string textBeforeButton, string buttonText, string linkUrl)
    {
        Type = "section";
        Text = new()
        {
            Type = FieldType.plain_text,
            Text = textBeforeButton,
        };
        Accessory = new Button(buttonText, linkUrl);
    }
}
