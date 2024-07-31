using BlazorMvvm.Model.Weather;
using BlazorMvvm.ViewModel.Abstractions.Weather;
using BlazorMvvm.ViewModel.Weather;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMvvm.ViewModel.Tests;
public class WeatherForecastViewModelUnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task GetSevenDayForecastAsync_CallsNotifyPropertyChangedOnceOnForecasts()
    {
        // Arrange
        WeatherForecast[] forecast = {};

        var forecaster = new Mock<IWeatherForecaster>();
        forecaster.Setup(f => f.GetSevenDayForecast()).Returns(forecast);

        var viewModel = new Mock<WeatherForecastTableViewModel>(forecaster.Object);

        // Act
        await viewModel.Object.GetSevenDayForecastAsync();

        // Assert
        viewModel.Verify(vm => vm.NotifyPropertyChanged(nameof(viewModel.Object.Forecasts)), Times.Once);
    }

    [Test]
    public async Task GetSevenDayForecastAsync_ReturnsCorrectForecast()
    {
        // Arrange
        WeatherForecast[] forecast = {
            new WeatherForecast(new DateOnly(2024, 08, 01), 20, "A"),
            new WeatherForecast(new DateOnly(2024, 08, 02), 15, "B"),
            new WeatherForecast(new DateOnly(2024, 08, 03), 18, "C"),
            new WeatherForecast(new DateOnly(2024, 08, 04), 32, "D")
        };

        var forecaster = new Mock<IWeatherForecaster>();
        forecaster.Setup(f => f.GetSevenDayForecast()).Returns(forecast);

        var viewModel = new Mock<WeatherForecastTableViewModel>(forecaster.Object);

        DailyWeatherForecast[] expectedResult = {
            new DailyWeatherForecast(new DateOnly(2024, 08, 01), 20, "A"),
            new DailyWeatherForecast(new DateOnly(2024, 08, 02), 15, "B"),
            new DailyWeatherForecast(new DateOnly(2024, 08, 03), 18, "C"),
            new DailyWeatherForecast(new DateOnly(2024, 08, 04), 32, "D")
        };

        // Act
        await viewModel.Object.GetSevenDayForecastAsync();

        // Assert
        Assert.That(viewModel.Object.Forecasts, Is.EquivalentTo(expectedResult));
    }
}
