using BlazorMvvm.Model.Weather;
using BlazorMvvm.ViewModel.Abstractions.Weather;
using BlazorMvvm.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMvvm.ViewModel.Weather;
public class WeatherForecastTableViewModel : ViewModelBase, IWeatherForecastTableViewModel
{
    private readonly IWeatherForecaster _weatherForecaster;
    private DailyWeatherForecast[]? _forecasts;

    public WeatherForecastTableViewModel(IWeatherForecaster weatherForecaster) 
    {
        _weatherForecaster = weatherForecaster;
    }

    public DailyWeatherForecast[]? Forecasts { get { return _forecasts; } set { _forecasts = value; NotifyPropertyChanged(); } }

    public async Task GetSevenDayForecastAsync()
    {
        // Simulate asynchronous loading to demonstrate a loading indicator
        await Task.Delay(500);

        Forecasts = _weatherForecaster
            .GetSevenDayForecast()
            .Select(x => 
                new DailyWeatherForecast(x.Date, x.TemperatureC, x.Summary)
                )
            .ToArray();
    }
}
