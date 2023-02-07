FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TrafficMarketBot/TrafficMarketBot.csproj", "TrafficMarketBot/"]
RUN dotnet restore "TrafficMarketBot/TrafficMarketBot.csproj"
COPY . .
WORKDIR "/src/TrafficMarketBot"
RUN dotnet build "TrafficMarketBot.csproj" -c Development -o /app/build

FROM build AS publish
RUN dotnet publish "TrafficMarketBot.csproj" -c Development -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrafficMarketBot.dll"]
