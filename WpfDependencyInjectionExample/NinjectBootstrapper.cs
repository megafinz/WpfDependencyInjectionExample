using Ninject;
using System;

namespace WpfDependencyInjectionExample;

internal static class NinjectBootstrapper
{
    // Just an alternative bootstrapper that show how to use a different DI container.
    public static IServiceProvider Bootstrap()
    {
        var kernel = new StandardKernel();

        kernel.Bind<IFancyRepository>().To<InMemoryFancyRepository>().InSingletonScope();
        kernel.Bind<FancyParser>().ToSelf();
        kernel.Bind<MainWindowViewModel>().ToSelf();
        kernel.Bind<SubMainViewModel>().ToSelf();

        return kernel;
    }
}
