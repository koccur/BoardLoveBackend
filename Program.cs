using BoardLove.Models;
using Microsoft.OpenApi.Models;
using BoardLove.API;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BoardLove") ?? "Data Source=BoardLove.db";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlite<GameDb>(connectionString);
builder.Services.AddSqlite<EventGameDb>(connectionString);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BoardLove API", Description = "BoardLove ", Version = "v1" });
});


// Add services to the container.
builder.Services.AddControllers();

Utilities.CreateAndRunApp(builder);
