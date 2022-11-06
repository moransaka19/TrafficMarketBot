namespace TrafficMarketBot.Commands;

public interface ICommand
{
    public Task Execute(long chatId, long messageId);
}