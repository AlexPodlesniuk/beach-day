using BeachDayFinder.BuildingBlocks.Api.Abstractions;
using BeachDayFinder.BuildingBlocks.Messaging;
using BeachDayFinder.Reporting.Application;
using BeachDayFinder.Reporting.Persistence;

const string EndpointName = "Reporting";
var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppSettings();
builder.Host.UseMessaging(EndpointName);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddApplicationLayer(builder.Configuration);

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();