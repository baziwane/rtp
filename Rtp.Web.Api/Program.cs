
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Rtp.Web.Api
{
    public class Program
    {
        public static void Main(string[] arguments) =>
            CreateHostBuilder(arguments).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] arguments)
        {
            return Host.CreateDefaultBuilder(arguments)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.UseStartup<Startup>());
        }
    }
}

/*

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StorageBroker>();
builder.Services.AddScoped<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<ILogger, Logger<LoggingBroker>>();
builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
*/



