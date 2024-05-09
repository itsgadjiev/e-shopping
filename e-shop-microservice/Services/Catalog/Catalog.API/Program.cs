using Marten;
using Microsoft.Extensions.Options;
using Weasel.Core;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);

}).UseLightweightSessions();

builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();

builder.Services.AddLogging(builder =>
{
    builder.AddConsole(); 
});


var app = builder.Build();



app.MapCarter();

app.Run();
