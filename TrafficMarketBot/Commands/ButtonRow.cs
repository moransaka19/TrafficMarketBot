using TrafficMarketBot.Commands.Interfaces;
using TrafficMarketBot.Controllers.Models;

namespace TrafficMarketBot.Commands;

public class ButtonRow : IButtonRow
{
    public readonly List<KeyboardButton> Buttons;

    public ButtonRow()
    {
        Buttons = new List<KeyboardButton>();
    }

    public IButtonRow AddButton(string buttonText)
    {
        Buttons.Add(new KeyboardButton(buttonText));

        return this;
    }
}

