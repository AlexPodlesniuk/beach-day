using BeachDayFinder.BuildingBlocks.Api.Abstractions;
using BeachDayFinder.BuildingBlocks.Messaging;
using BeachDayFinder.Prediction.Api.Middlewares;
using BeachDayFinder.Prediction.Application;

const string EndpointName = "Prediction";
var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppSettings();
builder.Host.UseMessaging(EndpointName);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationLayer(builder.Configuration);

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ApiKeyVerificationMiddleware>();
app.Run();