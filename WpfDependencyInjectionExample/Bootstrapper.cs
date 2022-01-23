using Microsoft.Extensions.DependencyInjection;
using System;

namespace WpfDependencyInjectionExample;

internal static class Bootstrapper
{
    // This is the so-called Composition Root. Here you register all dependencies and their lifetimes.
    // When you call App.Current.Services.GetService<T>(), IServiceProvider (in this case this is Ninject kernel object)
    // will try to instantiate T along with all it's dependencies (constructor parameters) recursively.
    // E.g. when we call App.Current.Services.GetService<MainWindowViewModel>() inside MainWindow's constructor,
    // it will create an instance of MainWindowViewModel, pass into it's constructor an instance of IFancyRepository
    // (which concrete type is registered to be InMemoryFancyRepository, and since it's registered as a singleton,
    // it will only be created once, and all subsequent attempts to instantiate it, like in FancyParser or SubMainViewModel,
    // will yield the exact same instance).
    public static IServiceProvider Bootstrap()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IFancyRepository, InMemoryFancyRepository>();
        services.AddTransient<FancyParser>();
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<SubMainViewModel>();

        return services.BuildServiceProvider();
    }
}
