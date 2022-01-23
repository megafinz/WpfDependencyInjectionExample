using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace WpfDependencyInjectionExample
{
    public partial class App
    {
        public App()
        {
            Services = Bootstrapper.Bootstrap();
            InitializeComponent();
            RunBackgroundTasks();
        }

        public new static App Current => (App) Application.Current;

        public IServiceProvider Services { get; }

        private void RunBackgroundTasks()
        {
            var parser = Services.GetRequiredService<FancyParser>();
            var _ = parser.Run();
        }
    }
}
