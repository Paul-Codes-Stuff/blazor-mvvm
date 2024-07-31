using BlazorMvvm.ViewModel.Objects.Weather;
using System.ComponentModel;

namespace BlazorMvvm.ViewModel.Abstractions.Weather;
public interface IWeatherForecastTableViewModel : INotifyPropertyChanged
{
    DailyWeatherForecast[]? Forecasts { get; }

    Task GetSevenDayForecastAsync();
}
