using BlazorMvvm.Model.Abstractions;
using BlazorMvvm.ViewModel.Calculator;
using Moq;

namespace BlazorMvvm.ViewModel.Tests;

public class CalculatorViewModelUnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(1, 1)]
    [TestCase(2, 5)]
    [TestCase(0, 47)]
    [TestCase(-47, 5)]
    [TestCase(5, -47)]
    [TestCase(0 ,0)]
    public void PerformAddition_ReturnsValueFromCalculator(int number1, int number2)
    {
        // Arrange
        int total = number1 + number2;
        var calculator = new Mock<ISimpleCalculator>();
        calculator.Setup(c => c.Add(number1, number2)).Returns(total);
        var viewModel = new CalculatorViewModel(calculator.Object);

        // Act
        viewModel.Number1 = number1;
        viewModel.Number2 = number2;
        viewModel.PerformAddition();

        // Assert
        Assert.That(viewModel.Result, Is.EqualTo(total));
    }

    [TestCase(1, 1)]
    [TestCase(2, 5)]
    [TestCase(0, 47)]
    [TestCase(-47, 5)]
    [TestCase(5, -47)]
    [TestCase(0, 0)]
    public void PerformSubtraction_ReturnsValueFromCalculator(int number1, int number2)
    {
        // Arrange
        int total = number1 - number2;
        var calculator = new Mock<ISimpleCalculator>();
        calculator.Setup(c => c.Subtract(number1, number2)).Returns(total);
        var viewModel = new CalculatorViewModel(calculator.Object);

        // Act
        viewModel.Number1 = number1;
        viewModel.Number2 = number2;
        viewModel.PerformSubtraction();

        // Assert
        Assert.That(viewModel.Result, Is.EqualTo(total));
    }

    [TestCase(1, null)]
    [TestCase(null, 5)]
    [TestCase(null, null)]
    public void PerformAddition_WithNullInput_ReturnsErrorMessage(int? number1, int? number2)
    {
        // Arrange
        var calculator = new Mock<ISimpleCalculator>();
        calculator.Setup(c => c.Add(0, 0)).Returns(0);
        var viewModel = new CalculatorViewModel(calculator.Object);

        // Act
        viewModel.Number1 = number1;
        viewModel.Number2 = number2;
        viewModel.PerformAddition();

        // Assert
        Assert.That(viewModel.Message == "You must enter 2 numbers!");
    }

    [TestCase(1, null)]
    [TestCase(null, 5)]
    [TestCase(null, null)]
    public void PerformSubtraction_WithNullInput_ReturnsErrorMessage(int? number1, int? number2)
    {
        // Arrange
        var calculator = new Mock<ISimpleCalculator>();
        calculator.Setup(c => c.Subtract(0, 0)).Returns(0);
        var viewModel = new CalculatorViewModel(calculator.Object);

        // Act
        viewModel.Number1 = number1;
        viewModel.Number2 = number2;
        viewModel.PerformSubtraction();

        // Assert
        Assert.That(viewModel.Message == "You must enter 2 numbers!");
    }

    [TestCase(1, 1)]
    [TestCase(2, 5)]
    [TestCase(0, 47)]
    [TestCase(-47, 5)]
    [TestCase(5, -47)]
    [TestCase(0, 0)]
    public void PerformAddition_CallsOnceNotifyPropertyChangedOnResult(int number1, int number2)
    {
        // Arrange
        int total = number1 + number2;
        var calculator = new Mock<ISimpleCalculator>();
        calculator.Setup(c => c.Add(number1, number2)).Returns(total);
        var viewModel = new Mock<CalculatorViewModel>(calculator.Object);

        // Act
        viewModel.Object.Number1 = number1;
        viewModel.Object.Number2 = number2;
        viewModel.Object.PerformAddition();

        // Assert
        viewModel.Verify(vm => vm.NotifyPropertyChanged(nameof(viewModel.Object.Result)), Times.Once);
    }

    [TestCase(1, 1)]
    [TestCase(2, 5)]
    [TestCase(0, 47)]
    [TestCase(-47, 5)]
    [TestCase(5, -47)]
    [TestCase(0, 0)]
    public void PerformAddition_CallsOnceNotifyPropertyChangedOnMessage(int number1, int number2)
    {
        // Arrange
        int total = number1 + number2;
        var calculator = new Mock<ISimpleCalculator>();
        calculator.Setup(c => c.Add(number1, number2)).Returns(total);
        var viewModel = new Mock<CalculatorViewModel>(calculator.Object);

        // Act
        viewModel.Object.Number1 = number1;
        viewModel.Object.Number2 = number2;
        viewModel.Object.PerformAddition();

        // Assert
        viewModel.Verify(vm => vm.NotifyPropertyChanged(nameof(viewModel.Object.Message)), Times.Once);
    }

    [TestCase(1, 1)]
    [TestCase(2, 5)]
    [TestCase(0, 47)]
    [TestCase(-47, 5)]
    [TestCase(5, -47)]
    [TestCase(0, 0)]
    public void PerformSubtraction_CallsOnceNotifyPropertyChangedOnResult(int number1, int number2)
    {
        // Arrange
        int total = number1 - number2;
        var calculator = new Mock<ISimpleCalculator>();
        calculator.Setup(c => c.Add(number1, number2)).Returns(total);
        var viewModel = new Mock<CalculatorViewModel>(calculator.Object);

        // Act
        viewModel.Object.Number1 = number1;
        viewModel.Object.Number2 = number2;
        viewModel.Object.PerformSubtraction();

        // Assert
        viewModel.Verify(vm => vm.NotifyPropertyChanged(nameof(viewModel.Object.Result)), Times.Once);
    }

    [TestCase(1, 1)]
    [TestCase(2, 5)]
    [TestCase(0, 47)]
    [TestCase(-47, 5)]
    [TestCase(5, -47)]
    [TestCase(0, 0)]
    public void PerformSubtraction_CallsOnceNotifyPropertyChangedOnMessage(int number1, int number2)
    {
        // Arrange
        int total = number1 - number2;
        var calculator = new Mock<ISimpleCalculator>();
        calculator.Setup(c => c.Add(number1, number2)).Returns(total);
        var viewModel = new Mock<CalculatorViewModel>(calculator.Object);

        // Act
        viewModel.Object.Number1 = number1;
        viewModel.Object.Number2 = number2;
        viewModel.Object.PerformSubtraction();

        // Assert
        viewModel.Verify(vm => vm.NotifyPropertyChanged(nameof(viewModel.Object.Message)), Times.Once);
    }

    [TestCase(1, null)]
    [TestCase(null, 5)]
    [TestCase(null, null)]
    public void PerformAddition_WithNullInput_CallsTwiceNotifyPropertyChangedOnMessage(int? number1, int? number2)
    {
        // Arrange
        var calculator = new Mock<ISimpleCalculator>();
        calculator.Setup(c => c.Add(0, 0)).Returns(0);
        var viewModel = new Mock<CalculatorViewModel>(calculator.Object);

        // Act
        viewModel.Object.Number1 = number1;
        viewModel.Object.Number2 = number2;
        viewModel.Object.PerformAddition();

        // Assert
        viewModel.Verify(vm => vm.NotifyPropertyChanged(nameof(viewModel.Object.Message)), Times.Exactly(2));
    }

    [TestCase(1, null)]
    [TestCase(null, 5)]
    [TestCase(null, null)]
    public void PerformAddition_WithNullInput_DoesNotCallNotifyPropertyChangedOnResult(int? number1, int? number2)
    {
        // Arrange
        var calculator = new Mock<ISimpleCalculator>();
        calculator.Setup(c => c.Add(0, 0)).Returns(0);
        var viewModel = new Mock<CalculatorViewModel>(calculator.Object);

        // Act
        viewModel.Object.Number1 = number1;
        viewModel.Object.Number2 = number2;
        viewModel.Object.PerformAddition();

        // Assert
        viewModel.Verify(vm => vm.NotifyPropertyChanged(nameof(viewModel.Object.Result)), Times.Never);
    }

    [TestCase(1, null)]
    [TestCase(null, 5)]
    [TestCase(null, null)]
    public void PerformSubtraction_WithNullInput_CallsTwiceNotifyPropertyChangedOnMessage(int? number1, int? number2)
    {
        // Arrange
        var calculator = new Mock<ISimpleCalculator>();
        calculator.Setup(c => c.Subtract(0, 0)).Returns(0);
        var viewModel = new Mock<CalculatorViewModel>(calculator.Object);

        // Act
        viewModel.Object.Number1 = number1;
        viewModel.Object.Number2 = number2;
        viewModel.Object.PerformSubtraction();

        // Assert
        viewModel.Verify(vm => vm.NotifyPropertyChanged(nameof(viewModel.Object.Message)), Times.Exactly(2));
    }

    [TestCase(1, null)]
    [TestCase(null, 5)]
    [TestCase(null, null)]
    public void PerformSubtraction_WithNullInput_DoesNotCallNotifyPropertyChangedOnResult(int? number1, int? number2)
    {
        // Arrange
        var calculator = new Mock<ISimpleCalculator>();
        calculator.Setup(c => c.Subtract(0, 0)).Returns(0);
        var viewModel = new Mock<CalculatorViewModel>(calculator.Object);

        // Act
        viewModel.Object.Number1 = number1;
        viewModel.Object.Number2 = number2;
        viewModel.Object.PerformSubtraction();

        // Assert
        viewModel.Verify(vm => vm.NotifyPropertyChanged(nameof(viewModel.Object.Result)), Times.Never);
    }
}