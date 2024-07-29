using BlazorMvvm.ViewModel.Abstractions.Calculator;
using BlazorMvvm.ViewModel.Abstractions.Counter;
using BlazorMvvm.ViewModel.Abstractions.Weather;
using BlazorMvvm.ViewModel.Calculator;
using BlazorMvvm.ViewModel.Counter;
using BlazorMvvm.ViewModel.Weather;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorMvvm.ViewModel;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddViewModelServices(this IServiceCollection services)
    {
        return services
            .AddTransient<ICalculatorViewModel, CalculatorViewModel>()
            .AddTransient<IWeatherForecastTableViewModel, WeatherForecastTableViewModel>()
            .AddTransient<ICounterViewModel, CounterViewModel>()
            ;
    }
}
