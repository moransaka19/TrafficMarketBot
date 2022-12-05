using TelegramBotCore.Clients.Models;
using TrafficMarketBot.Commands.Interfaces;

namespace TelegramBotCore.Services.Interfaces;

public interface IMessageBuilder
{
    IMessageBuilder SetTextMessage(string text);
    IMessageBuilder AddButtonRow(Action<IButtonRow> buttonRow);
    IMessageBuilder AddReturnButton();
    SendMessageModel Build();
}

