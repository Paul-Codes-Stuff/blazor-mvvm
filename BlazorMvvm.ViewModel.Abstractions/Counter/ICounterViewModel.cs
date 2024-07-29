using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMvvm.ViewModel.Abstractions.Counter;
public interface ICounterViewModel : INotifyPropertyChanged
{
    int CurrentCount { get; }
    void IncrementCount();
}
