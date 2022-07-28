namespace Botje.Mtg.Api.Dtos.Slack.Events.Messages;

public class MessageGroups : MessageBase
{
    public string token { get; set; }
    public string team_id { get; set; }
    public string api_app_id { get; set; }
    public Event @event { get; set; }
    public string type { get; set; }
    public List<string> authed_teams { get; set; }
    public string event_id { get; set; }
    public int event_time { get; set; }
}

//public class Event
//{
//    public string type { get; set; }
//    public string channel { get; set; }
//    public string user { get; set; }
//    public string text { get; set; }
//    public string ts { get; set; }
//    public string event_ts { get; set; }
//    public string channel_type { get; set; }
//}
