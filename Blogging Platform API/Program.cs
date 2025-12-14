using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Services Area
builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler =
ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Middlewares Area
app.MapControllers();

app.Run();
