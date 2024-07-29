using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMvvm.ViewModel.Abstractions.Shared;
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