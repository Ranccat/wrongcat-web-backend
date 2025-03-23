using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Wrongcat.Api.Data;
using Wrongcat.Api.Services;

Env.Load();
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IDownloadService, DownloadService>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.UseCors("AllowSpecificOrigins");
app.MapControllers();

app.Run();
