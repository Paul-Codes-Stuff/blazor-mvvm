using BlazorMvvm.ViewModel.Abstractions.Counter;
using BlazorMvvm.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
