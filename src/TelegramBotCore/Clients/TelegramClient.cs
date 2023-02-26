using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using TelegramBotCore.Clients.Models;

namespace TelegramBotCore.Clients;

public class TelegramClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<TelegramClient> _logger;

    public TelegramClient(HttpClient httpClient,
        ILogger<TelegramClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<CreatedMessageModel> SendMessageAsync(SendMessageModel model)
    {
        var response = await PostAsync(model, "sendMessage");

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("The message was not send to chat with id: {chatId}", model.ChatId);
        }
        
        var content = await response.Content.ReadAsStringAsync();
        
        return JsonSerializer.Deserialize<CreatedMessageModel>(
            content,
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = new SnakeCaseNamingPolicy()
            }) ?? throw new InvalidOperationException();
    }

    public async Task SetWebhookAsync(SetWebhookRequestModel model)
    {
        var response = await PostAsync(model, "setWebhook");

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError($"{response.ReasonPhrase}; status code - {response.StatusCode}\nThe webhook url was not send to Telegram");
            return;
        }
        
        _logger.LogInformation("Webhook url has been set: {url}",model.Url);
    }

    private async Task<HttpResponseMessage> PostAsync(object model, string uri)
    {
        var body = JsonSerializer.Serialize(
            model,
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
        return await _httpClient.PostAsync(
            uri,
            new StringContent(body, Encoding.UTF8, MediaTypeNames.Application.Json));
    }
}