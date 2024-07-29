namespace BlazorMvvm.Model.Weather;

public interface IWeatherForecaster
{
    WeatherForecast[] GetSevenDayForecast();
}