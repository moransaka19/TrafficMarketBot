namespace TrafficMarketBot.Controllers;

public class Message
{
    public long MessageId { get; set; }
    public From From { get; set; }
    public Chat Chat { get; set; }
    public string Text { get; set; }
    public int Date { get; set; }
}