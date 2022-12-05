using TelegramBotCore.Clients.Models;

namespace TelegramBotCore.Services.Interfaces;

public interface IBotCommand
{
    public Task Execute(UpdateMessageModel update);
}