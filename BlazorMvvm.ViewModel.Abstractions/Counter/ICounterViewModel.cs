using System.ComponentModel;

namespace BlazorMvvm.ViewModel.Abstractions.Counter;
public interface ICounterViewModel : INotifyPropertyChanged
{
    int CurrentCount { get; }
    void IncrementCount();
}
