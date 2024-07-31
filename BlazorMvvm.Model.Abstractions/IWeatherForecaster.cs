using BlazorMvvm.Model.Entities;

namespace BlazorMvvm.Model.Abstractions;

public interface IWeatherForecaster
{
    WeatherForecast[] GetSevenDayForecast();
}