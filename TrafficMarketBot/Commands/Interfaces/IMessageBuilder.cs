using TrafficMarketBot.Controllers.Models;

namespace TrafficMarketBot.Commands.Interfaces;

public interface IMessageBuilder
{
    IMessageBuilder SetTextMessage(string text);
    IMessageBuilder AddButtonRow(Action<IButtonRow> buttonRow);
    SendMessageModel Build();
}

