using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMvvm.ViewModel.Abstractions.Weather;
public interface IWeatherForecastTableViewModel : INotifyPropertyChanged
{
    DailyWeatherForecast[]? Forecasts { get; }

    Task GetSevenDayForecastAsync();
}
