FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/BeachDayFinder.Prediction.Api/BeachDayFinder.Prediction.Api.csproj", "Services/BeachDayFinder.Prediction.Api/"]
COPY ["BuildingBlocks/Application/BeachDayFinder.BuildingBlocks.Api.Abstractions/BeachDayFinder.BuildingBlocks.Api.Abstractions.csproj", "BuildingBlocks/Application/BeachDayFinder.BuildingBlocks.Api.Abstractions/"]
COPY ["BuildingBlocks/Persistence/BeachDayFinder.BuildingBlocks.Persistence/BeachDayFinder.BuildingBlocks.Persistence.csproj", "BuildingBlocks/Persistence/BeachDayFinder.BuildingBlocks.Persistence/"]
COPY ["BuildingBlocks/Application/BeachDayFinder.BuildingBlocks.Application/BeachDayFinder.BuildingBlocks.Application.csproj", "BuildingBlocks/Application/BeachDayFinder.BuildingBlocks.Application/"]
COPY ["BuildingBlocks/Domain/BeachDayFinder.BuildingBlocks.Domain/BeachDayFinder.BuildingBlocks.Domain.csproj", "BuildingBlocks/Domain/BeachDayFinder.BuildingBlocks.Domain/"]
COPY ["Services/BeachDayFinder.Prediction.Application/BeachDayFinder.Prediction.Application.csproj", "Services/BeachDayFinder.Prediction.Application/"]
COPY ["BuildingBlocks/Messaging/BeachDayFinder.BuildingBlocks.Messaging/BeachDayFinder.BuildingBlocks.Messaging.csproj", "BuildingBlocks/Messaging/BeachDayFinder.BuildingBlocks.Messaging/"]
COPY ["Services/BeachDayFinder.Prediction.Contracts/BeachDayFinder.Prediction.Contracts.csproj", "Services/BeachDayFinder.Prediction.Contracts/"]
COPY ["Services/BeachDayFinder.Prediction.Domain/BeachDayFinder.Prediction.Domain.csproj", "Services/BeachDayFinder.Prediction.Domain/"]
COPY ["Services/BeachDayFinder.Prediction.Integrations.OpenWeatherMap/BeachDayFinder.Prediction.Integrations.OpenWeatherMap.csproj", "Services/BeachDayFinder.Prediction.Integrations.OpenWeatherMap/"]
RUN dotnet restore "Services/BeachDayFinder.Prediction.Api/BeachDayFinder.Prediction.Api.csproj"
COPY . .
WORKDIR "/src/Services/BeachDayFinder.Prediction.Api"
RUN dotnet build "BeachDayFinder.Prediction.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BeachDayFinder.Prediction.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BeachDayFinder.Prediction.Api.dll"]
