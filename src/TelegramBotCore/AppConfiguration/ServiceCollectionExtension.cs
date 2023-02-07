using System.Collections.Immutable;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TelegramBotCore.Clients;
using TelegramBotCore.Data;
using TelegramBotCore.Services;
using TelegramBotCore.Services.Interfaces;

namespace TelegramBotCore.AppConfiguration;

public static class ServiceCollectionExtension
{
    public static void AddTelegramBot(
        this IServiceCollection collection,
        IConfiguration configuration,
        Assembly assembly)
    {
        collection.AddTransient<ICommandStorageService, CommandStorageServiceService>();

        collection.AddHttpClient<TelegramClient>(op =>
        {
            var baseAddress = configuration.GetConnectionString("TelegramBot");
            op.BaseAddress = new Uri(baseAddress);
        });

        // Registered commands dependencies
        var commandTypes = assembly.GetTypes()
            .Where(x => x.IsAssignableTo(typeof(IBotCommand)) &&
                        x.IsClass &&
                        !x.IsAbstract)
            .ToImmutableArray();

        foreach (var type in commandTypes)
        {
            collection.AddTransient(type);
        }

        collection.AddTransient<ICommandFactory, CommandFactory>(
            x => new CommandFactory(
                x.GetRequiredService<IServiceProvider>(),
                commandTypes));

        collection.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
        });

        collection.AddTransient<IRouteService, RouteService>();
    }
}