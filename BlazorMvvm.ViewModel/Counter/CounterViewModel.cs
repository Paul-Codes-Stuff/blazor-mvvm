using BlazorMvvm.ViewModel.Abstractions.Counter;
using BlazorMvvm.ViewModel.Shared;

namespace BlazorMvvm.ViewModel.Counter;
public class CounterViewModel : ViewModelBase, ICounterViewModel
{
    private int _count;
    public CounterViewModel()
    {
        _count = 0;
    }

    public int CurrentCount { get { return _count; } private set { _count = value; NotifyPropertyChanged(); } }

    public void IncrementCount()
    {
        CurrentCount++;
    }
}
