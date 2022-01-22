using System;
using System.Threading.Tasks;

namespace WpfDependencyInjectionExample;

internal sealed class FancyParser
{
    private readonly IFancyRepository _repo;

    public FancyParser(IFancyRepository repo)
    {
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
    }

    // Simulates asynchronous parsing of a file in the background and filling in the repo.
    public async Task Run()
    {
        _repo.Add(new FancyModel { Id = 1 });
        _repo.Add(new FancyModel { Id = 2 });
        _repo.Add(new FancyModel { Id = 3 });
        await Task.Delay(1000);
        _repo.Add(new FancyModel { Id = 4 });
        _repo.Add(new FancyModel { Id = 5 });
        _repo.Add(new FancyModel { Id = 6 });
        await Task.Delay(3000);
        _repo.Add(new FancyModel { Id = 7 });
        _repo.Add(new FancyModel { Id = 8 });
        _repo.Add(new FancyModel { Id = 9 });
        _repo.Add(new FancyModel { Id = 10 });
    }
}
