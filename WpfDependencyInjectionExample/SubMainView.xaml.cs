using Microsoft.Extensions.DependencyInjection;

namespace WpfDependencyInjectionExample;

internal partial class SubMainView
{
    public SubMainView()
    {
        InitializeComponent();
        DataContext = App.Current.Services.GetRequiredService<SubMainViewModel>();
    }
}
