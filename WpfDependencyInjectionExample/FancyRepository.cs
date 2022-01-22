using System;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace WpfDependencyInjectionExample;

internal interface IFancyRepository
{
    public void Add(FancyModel model);

    public IReadOnlyCollection<FancyModel> GetAll();

    public IObservable<FancyModel> Added { get; }
}

internal sealed class InMemoryFancyRepository: IFancyRepository
{
    private readonly List<FancyModel> _items = new();
    private readonly Subject<FancyModel> _added = new();

    public void Add(FancyModel model)
    {
        _items.Add(model);
        _added.OnNext(model);
    }

    public IReadOnlyCollection<FancyModel> GetAll() => _items.AsReadOnly();

    public IObservable<FancyModel> Added => _added;
}
