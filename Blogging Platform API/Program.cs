using System.Text.Json.Serialization;
using Blogging_Platform_API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services Area
builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler =
ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=DefaultConnection"));

var app = builder.Build();

// Middlewares Area
app.MapControllers();

app.Run();
