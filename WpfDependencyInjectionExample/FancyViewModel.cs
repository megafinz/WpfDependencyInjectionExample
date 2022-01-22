namespace WpfDependencyInjectionExample;

internal sealed class FancyViewModel
{
    public int Id { get; private init; }

    public static FancyViewModel FromModel(FancyModel model) => new() { Id = model.Id };
}
