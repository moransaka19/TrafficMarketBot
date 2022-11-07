using RestEase;
using TrafficMarketBot.Controllers.Models;

namespace TrafficMarketBot.Clients;

public interface ITelegramClient
{
    [Post("sendMessage")]
    Task<CreatedMessage> SendMessageAsync([Body] SendMessageModel model);

    [Get("setWebhook")]
    Task<HttpResponseMessage> SetWebhookAsync([Body] SetWebhookRequestModel model);

    [Post("deleteMessage")]
    Task<HttpResponseMessage> DeleteMessageAsync([Body] DeleteMessageModel model);
}

public class SetWebhookRequestModel
{
    public string Url { set; get; }
}

public partial class CreatedMessage
{
    public bool Ok { get; set; }
    public Result Result { get; set; }
}

public partial class Result
{
    public long MessageId { get; set; }
    public Chat From { get; set; }
    public Chat Chat { get; set; }
    public long Date { get; set; }
    public string Text { get; set; }
}

public partial class Chat
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string Username { get; set; }
    public string Type { get; set; }
    public bool IsBot { get; set; }
}

public class DeleteMessageModel
{
    public long ChatId { get; set; }
    public long MessageId { get; set; }
}