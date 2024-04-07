var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddCarter();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
var app = builder.Build();






app.MapCarter();
app.MapControllers();

app.Run();
