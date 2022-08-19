using Refit;

namespace Slack.Client;

public interface ISlackClient
{
    [Post("/chat.postMessage")]
    Task<ApiResponse<string>> PostMessage(PostMessage message);

    //[Post("/chat.postEphemeral")]
    //Task PostEphemeral(PostEphemeral ephemeralMessage);
}