using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading;

namespace WpfDependencyInjectionExample;

internal sealed class MainWindowViewModel
{
    private readonly IFancyRepository _repo;

    public MainWindowViewModel(IFancyRepository repository)
    {
        _repo = repository ?? throw new ArgumentNullException(nameof(repository));

        InitializeFancies();
    }

    private void InitializeFancies()
    {
        var fancies = _repo.GetAll();

        foreach (var fancy in fancies)
        {
            Fancies.Add(FancyViewModel.FromModel(fancy));
        }

        // You might need to dispose the subscription if your View Model has shorter lifetime than repo.
        var _ = _repo.Added
            // In order for ObservableCollection to work correctly, you need to access it on the Dispatcher (i.e. UI) thread.
            // When ObserveOn is called, SynchronizationContext.Current points to a UI Synchronization Context since
            // MainWindowViewModel is being created on the UI thread and there are no further thread switches.
            // Alternatively you can call BindingOperations.EnableCollectionSynchronization(…) on your collection with a lock object once,
            // for example in constructor. This will ensure that ObservableCollection is will eventually receive all changes on UI thread
            // and sync with the View that it is bound to.
            .ObserveOn(SynchronizationContext.Current!)
            .Subscribe(newFancy => Fancies.Add(FancyViewModel.FromModel(newFancy)));
    }

    public ObservableCollection<FancyViewModel> Fancies { get; } = new ();
}
