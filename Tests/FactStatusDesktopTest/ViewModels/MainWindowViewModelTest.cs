using FactStatus.Desktop.ViewModels;

namespace FactStatus.Desktop.Test.ViewModels;

public class MainWindowViewModelTest {
    [Fact]
    public void Greeting_初期値を取得できる() {
        var viewModel = new MainWindowViewModel();

        Assert.Equal("Welcome to Avalonia!", viewModel.Greeting);
    }
}
