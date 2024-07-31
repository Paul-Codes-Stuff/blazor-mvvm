using BlazorMvvm.ViewModel.Counter;
using Moq;

namespace BlazorMvvm.ViewModel.Tests;
public class CounterViewModelUnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PerformIncrement_CallsNotifyPropertyChangedOnceOnCurrentCount()
    {
        // Arrange
        var viewModel = new Mock<CounterViewModel>();

        // Act
        viewModel.Object.IncrementCount();

        // Assert
        viewModel.Verify(vm => vm.NotifyPropertyChanged(nameof(viewModel.Object.CurrentCount)), Times.Once);
    }

    [Test]
    public void PerformIncrement_IncrementsCurrentCount()
    {
        // Arrange
        var viewModel = new CounterViewModel();
        var initialCount = viewModel.CurrentCount;
        var expectedCount = initialCount + 1;

        // Act
        viewModel.IncrementCount();

        // Assert
        Assert.That(viewModel.CurrentCount, Is.EqualTo(expectedCount));
    }
}
