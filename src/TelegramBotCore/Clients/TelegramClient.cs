using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TelegramBotCore.Clients.Models;

namespace TelegramBotCore.Clients;

public class TelegramClient
{
    private readonly HttpClient _httpClient;

    public TelegramClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CreatedMessageModel> SendMessageAsync(SendMessageModel model)
    {
        var response = await PostAsync(model, "sendMessage");
        var content = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            //TODO: Log it
        }

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
            //TODO: Log it
        }
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