// <auto-generated/>

namespace BlazorMvvm.Views.Components;
public partial class WeatherForecastTableComponent
{
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await ViewModel.GetSevenDayForecastAsync();
    }
}