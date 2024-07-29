using System.ComponentModel;

namespace BlazorMvvm.ViewModel.Abstractions.Calculator;

public interface ICalculatorViewModel : INotifyPropertyChanged
{
    int? Number1 { get; set; }
    int? Number2 { get; set; }
    int? Result { get; }
    string Message { get; }

    void PerformAddition();
    void PerformSubtraction();
}
