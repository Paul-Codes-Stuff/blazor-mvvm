using BlazorMvvm.Model.Abstractions;

namespace BlazorMvvm.Model;

public class SimpleCalculator : ISimpleCalculator
{
    public SimpleCalculator()
    {
    }

    public int Add(int a, int b) { return a + b; }
    public int Subtract(int a, int b) { return a - b; }

}
