using Refit;

namespace Slack.Client;

public interface ISlackClient
{
    [Post("/chat.postMessage")]
    Task PostMessage(PostMessage message);

    //[Post("/chat.postEphemeral")]
    //Task PostEphemeral(PostEphemeral ephemeralMessage);
}