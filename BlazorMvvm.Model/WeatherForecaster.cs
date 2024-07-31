using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorMvvm.Model.Abstractions;
using BlazorMvvm.Model.Entities;

namespace BlazorMvvm.Model;
public class WeatherForecaster : IWeatherForecaster
{
    public WeatherForecaster()
    {
    }

    public WeatherForecast[] GetSevenDayForecast()
    {
        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        return Enumerable.Range(1, 7)
            .Select(index =>
                new WeatherForecast(
                    startDate.AddDays(index),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                    )
                )
            .ToArray();
    }
}
