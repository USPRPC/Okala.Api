using Okala.Application;

namespace Okala.API.Settings;

public static class RedSetting
{
    public static void AddRedSettingConfiguration(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<OpenWeatherMapSetting>(configuration.GetSection("OpenWeatherMapSetting"));
    }
}