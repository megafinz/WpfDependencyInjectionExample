using System;
using System.Collections.ObjectModel;

namespace WpfDependencyInjectionExample;

internal sealed class SubMainViewModel
{
    private readonly IFancyRepository _repo;

    public SubMainViewModel(IFancyRepository repo)
    {
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        InitializeFancies();
    }

    private void InitializeFancies()
    {
        var fancies = _repo.GetAll();

        foreach (var fancy in fancies)
        {
            Fancies.Add(FancyViewModel.FromModel(fancy));
        }
    }

    public ObservableCollection<FancyViewModel> Fancies { get; } = new();
}
