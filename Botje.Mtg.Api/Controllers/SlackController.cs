using Botje.Mtg.Api.Dtos.Slack.Events;
using Microsoft.AspNetCore.Mvc;
using Slack.Dto;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Botje.Mtg.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SlackController : ControllerBase
{
    private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

    [HttpPost("events")]
    public async Task<IActionResult> Events()
    {
        string rawJson = "";
        using (var sr = new StreamReader(Request.Body))
        {
            rawJson = await sr.ReadToEndAsync();
        }

        Console.WriteLine($"Raw request: \n{rawJson}");

        EventWrapper message = JsonSerializer.Deserialize<EventWrapper>(rawJson, _serializerOptions)!;

        // Handle url verification flow
        if (message.Type == "url_verification")
        {
            UrlVerification urlVerification = JsonSerializer.Deserialize<UrlVerification>(rawJson, _serializerOptions)!;
            return Ok(urlVerification.Challenge);
        }


        // Handle card search inquiry 

        return Ok();
        //var distinctCards = flattenedRawCardList.GetDistinctCards();

        //// Set the channel and timestamp to respond to a message in a thread
        //Message fullMessage = new Message { Channel = message.Channel, Thread_ts = message.Timestamp }.SetText("Cards found:");
        //foreach (Card distinctCard in distinctCards)
        //{
        //    // Always add the found card name, multiverse id and set name to the message to give feedback on the found cards
        //    fullMessage.Text += $"{distinctCard.Name} - {distinctCard.MultiverseId} - {distinctCard.SetName} \r\n";

        //    try
        //    {
        //        Card cardWithImage = flattenedRawCardList.Where(c => c.Name == distinctCard.Name).GetMostRecentCardWithImage();

        //        fullMessage.AddAttachment(new Attachment("")
        //        {
        //            Title = cardWithImage.Name,
        //            Image_url = cardWithImage.ImageUrl.ToString()
        //        }.AddField(new AttachmentField("Legality",
        //                string.Join(",\n", cardWithImage.Legalities.Select(l => $"*{l.Format}*: {l.LegalityName}")),
        //                true))
        //            .AddField(new AttachmentField("Set",
        //                string.Join(", ", cardWithImage.SetName),
        //                true)));
        //    }
        //    catch (CardWithoutImageException e)
        //    {
        //        _logger.LogError($"{nameof(SlackEventHandler)} | {nameof(EventHandler)} | EXCEPTION {e.Message}");

        //        // Add an attachment to the full message. This attachment is the card info in text format
        //        fullMessage.AddAttachment(new Attachment($"{distinctCard.Name} | {distinctCard.ManaCost}") { }
        //            .AddField(new AttachmentField("Ruletext", distinctCard.Text))
        //            .AddField(new AttachmentField("Type", distinctCard.Type) { Short = true })
        //            .AddField(new AttachmentField("Power", $"{(!string.IsNullOrEmpty(distinctCard.Power) ? $"{distinctCard.Power}/{distinctCard.Toughness}" : distinctCard.Loyalty)}") { Short = true }));
        //    }
        //}
    }

    public static IEnumerable<string> GetCardNamesWithinSquareBrackets(string input)
    {
        Regex bracketNameMatcher = new Regex(@"\[\[(.*?)\]\]");

        MatchCollection matchedNames = bracketNameMatcher.Matches(input);
        return matchedNames.Select(m => m.Groups[1].Value);
    }
}
