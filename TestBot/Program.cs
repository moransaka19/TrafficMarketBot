using System.Net.Mime;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

const string BaseBotURL = "https://api.telegram.org";
const string Bot = "bot";
const string BotId = "5466565571:AAHCf_vF2MW3hFmTVR4fzkiDnX9WLpXovmc";
const string WebhookUrl = "https://9fb5-193-105-7-125.eu.ngrok.io/webhook";

const string setWebhookUrl = "setWebhook";

using var httpClient = new HttpClient();

httpClient.BaseAddress = new Uri(BaseBotURL + "/" + Bot + BotId + "/");
var setWebhookRequest = new SetWebhookRequestModel { Url = WebhookUrl };
DefaultContractResolver contractResolver = new DefaultContractResolver
{
    NamingStrategy = new SnakeCaseNamingStrategy()
};
var body = JsonConvert.SerializeObject(setWebhookRequest, new JsonSerializerSettings
{
    ContractResolver = contractResolver
});
var responseMessage = await httpClient.PostAsync(setWebhookUrl,
    new StringContent(body, Encoding.UTF8, MediaTypeNames.Application.Json));

var responseString = responseMessage.Content.ReadAsStringAsync();


public class SetWebhookRequestModel
{
    public string Url { get; set; }
}