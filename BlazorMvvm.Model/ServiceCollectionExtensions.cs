using BlazorMvvm.Model.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorMvvm.Model;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddModelServices(this IServiceCollection services)
    {
        return services
            .AddScoped<ISimpleCalculator, SimpleCalculator>()
            .AddScoped<IWeatherForecaster, WeatherForecaster>()
            ;
    }
}
