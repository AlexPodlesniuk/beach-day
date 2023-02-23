FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/BeachDayFinder.Reporting.Api/BeachDayFinder.Reporting.Api.csproj", "Services/BeachDayFinder.Reporting.Api/"]
COPY ["BuildingBlocks/Application/BeachDayFinder.BuildingBlocks.Api.Abstractions/BeachDayFinder.BuildingBlocks.Api.Abstractions.csproj", "BuildingBlocks/Application/BeachDayFinder.BuildingBlocks.Api.Abstractions/"]
COPY ["BuildingBlocks/Persistence/BeachDayFinder.BuildingBlocks.Persistence/BeachDayFinder.BuildingBlocks.Persistence.csproj", "BuildingBlocks/Persistence/BeachDayFinder.BuildingBlocks.Persistence/"]
COPY ["BuildingBlocks/Application/BeachDayFinder.BuildingBlocks.Application/BeachDayFinder.BuildingBlocks.Application.csproj", "BuildingBlocks/Application/BeachDayFinder.BuildingBlocks.Application/"]
COPY ["BuildingBlocks/Domain/BeachDayFinder.BuildingBlocks.Domain/BeachDayFinder.BuildingBlocks.Domain.csproj", "BuildingBlocks/Domain/BeachDayFinder.BuildingBlocks.Domain/"]
COPY ["Services/BeachDayFinder.Reporting.Application/BeachDayFinder.Reporting.Application.csproj", "Services/BeachDayFinder.Reporting.Application/"]
COPY ["Services/BeachDayFinder.Prediction.Contracts/BeachDayFinder.Prediction.Contracts.csproj", "Services/BeachDayFinder.Prediction.Contracts/"]
COPY ["BuildingBlocks/Messaging/BeachDayFinder.BuildingBlocks.Messaging/BeachDayFinder.BuildingBlocks.Messaging.csproj", "BuildingBlocks/Messaging/BeachDayFinder.BuildingBlocks.Messaging/"]
COPY ["Services/BeachDayFinder.Reporting.Domain/BeachDayFinder.Reporting.Domain.csproj", "Services/BeachDayFinder.Reporting.Domain/"]
COPY ["Services/BeachDayFinder.Reporting.Persistence/BeachDayFinder.Reporting.Persistence.csproj", "Services/BeachDayFinder.Reporting.Persistence/"]
COPY ["BuildingBlocks/Persistence/BeachDayFinder.BuildingBlocks.Persistence.Mongo/BeachDayFinder.BuildingBlocks.Persistence.Mongo.csproj", "BuildingBlocks/Persistence/BeachDayFinder.BuildingBlocks.Persistence.Mongo/"]
RUN dotnet restore "Services/BeachDayFinder.Reporting.Api/BeachDayFinder.Reporting.Api.csproj"
COPY . .
WORKDIR "/src/Services/BeachDayFinder.Reporting.Api"
RUN dotnet build "BeachDayFinder.Reporting.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BeachDayFinder.Reporting.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BeachDayFinder.Reporting.Api.dll"]
