using BlazorMvvm.Model.Calculator;
using BlazorMvvm.ViewModel.Abstractions.Calculator;
using BlazorMvvm.ViewModel.Shared;
using System.Diagnostics.CodeAnalysis;

namespace BlazorMvvm.ViewModel.Calculator;

public class CalculatorViewModel : ViewModelBase, ICalculatorViewModel
{
    private int? _result;
    private string _message;
    private readonly ISimpleCalculator _calculator;

    public CalculatorViewModel(ISimpleCalculator calculator)
    {
        _calculator = calculator;
        _message = string.Empty;
    }

    public int? Number1 { get; set; }
    public int? Number2 { get; set; }

    public int? Result { get { return _result; } private set { _result = value; NotifyPropertyChanged(); } }
    public string Message { get { return _message; } private set { _message = value; NotifyPropertyChanged(); } }

    public void PerformAddition()
    {
        ClearMessage();

        if (EntryIsValid())
            Result = _calculator.Add(Number1.Value, Number2.Value);
        else
            SetError();
    }

    public void PerformSubtraction()
    {
        ClearMessage();

        if (EntryIsValid())
            Result = _calculator.Subtract(Number1.Value, Number2.Value);
        else
            SetError();
    }

    private void ClearMessage() => Message = string.Empty;
    private void SetError() => Message = "You must enter 2 numbers!";

    [MemberNotNullWhen(true, nameof(Number1), nameof(Number2))]
    private bool EntryIsValid()
    {
        return Number1 is not null && Number2 is not null;
    }
}
