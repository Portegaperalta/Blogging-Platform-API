using System.Text.Json.Serialization;
using Blogging_Platform_API.Data;
using Blogging_Platform_API.Data.Repositories;
using Blogging_Platform_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services Area
builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler =
ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=DefaultConnection"));

var app = builder.Build();

// Middlewares Area
app.MapControllers();

app.Run();
