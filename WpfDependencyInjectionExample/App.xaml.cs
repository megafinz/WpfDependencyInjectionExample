using Microsoft.Extensions.DependencyInjection;
using Ninject;
using System;
using System.Windows;

namespace WpfDependencyInjectionExample
{
    public partial class App
    {
        public App()
        {
            Services = Bootstrap();
            InitializeComponent();
            RunBackgroundTasks();
        }

        public new static App Current => (App) Application.Current;

        public IServiceProvider Services { get; }

        // This is the so-called Composition Root. Here you register all dependencies and their lifetimes.
        // When you call App.Current.Services.GetService<T>(), IServiceProvider (in this case this is Ninject kernel object)
        // will try to instantiate T along with all it's dependencies (constructor parameters) recursively.
        // E.g. when we call App.Current.Services.GetService<MainWindowViewModel>() inside MainWindow's constructor,
        // it will create an instance of MainWindowViewModel, pass into it's constructor an instance of IFancyRepository
        // (which concrete type is registered to be InMemoryFancyRepository, and since it's registered as a singleton,
        // it will only be created once, and all subsequent attempts to instantiate it, like in FancyParser or SubMainViewModel,
        // will yield the exact same instance).
        private static IServiceProvider Bootstrap()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IFancyRepository>().To<InMemoryFancyRepository>().InSingletonScope();
            kernel.Bind<MainWindowViewModel>().ToSelf();
            kernel.Bind<SubMainViewModel>().ToSelf();

            return kernel;
        }

        private void RunBackgroundTasks()
        {
            var parser = Services.GetRequiredService<FancyParser>();
            var _ = parser.Run();
        }
    }
}
