using Microsoft.OpenApi.Models;
using Okala.API.Middlewares;
using Okala.API.Settings;
using Okala.Infrastructure.Configurations;

namespace Okala.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Okala Open Weather Map",
                Version = "v1",
                Description = "Open Weather Map Task For Okala"
            });
        });

        builder.Services.AddRedSettingConfiguration(builder.Configuration);
        builder.Services.ConfigureServices();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenWeatherMap v1");
                options.DocumentTitle = "OpenWeatherMap";
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.Run();
    }
}