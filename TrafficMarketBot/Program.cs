using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase.HttpClientFactory;
using TrafficMarketBot.Clients;
using TrafficMarketBot.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRestEaseClient<ITelegramClient>("https://api.telegram.org/bot5466565571:AAHCf_vF2MW3hFmTVR4fzkiDnX9WLpXovmc/",
    op =>
    {
        op.JsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };
    });
builder.Services.AddTransient<TestCommand>();
builder.Services.AddTransient<MainCommand>();
builder.Services.AddControllers().AddNewtonsoftJson(op =>
{
    op.SerializerSettings.ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new SnakeCaseNamingStrategy()
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
