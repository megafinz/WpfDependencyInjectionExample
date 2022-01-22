using Microsoft.Extensions.DependencyInjection;

namespace WpfDependencyInjectionExample;

internal partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = App.Current.Services.GetRequiredService<MainWindowViewModel>();
    }
}
