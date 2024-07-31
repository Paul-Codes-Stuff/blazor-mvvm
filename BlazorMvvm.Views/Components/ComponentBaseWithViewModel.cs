using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace BlazorMvvm.Views.Components;
public abstract class ComponentBaseWithViewModel<TViewModel> :
    ComponentBase,
    IDisposable
    where TViewModel : INotifyPropertyChanged
{
    [Inject]
    protected TViewModel ViewModel { get; init; }

    protected override void OnInitialized()
    {
        ViewModel.PropertyChanged += OnChangeHandler;
    }

    private async void OnChangeHandler(object? sender, PropertyChangedEventArgs e)
    {
        await InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        ViewModel.PropertyChanged -= OnChangeHandler;
    }
}