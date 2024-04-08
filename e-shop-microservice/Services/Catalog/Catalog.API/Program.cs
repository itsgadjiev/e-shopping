var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddCarter();
builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Default")!);
    
}).UseLightweightSessions();
var app = builder.Build();

app.MapCarter();
app.MapControllers();

app.Run();
