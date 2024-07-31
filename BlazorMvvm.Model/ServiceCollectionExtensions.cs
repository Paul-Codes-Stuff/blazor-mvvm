using BlazorMvvm.Model.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
