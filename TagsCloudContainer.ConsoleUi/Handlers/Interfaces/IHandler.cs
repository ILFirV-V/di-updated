using TagsCloudContainer.ConsoleUi.Options.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Handlers.Interfaces;

public interface IHandler<in TOptions>
    where TOptions : IOptions
{
    public string Execute(TOptions options);
}