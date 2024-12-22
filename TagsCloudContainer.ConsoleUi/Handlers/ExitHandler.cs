using TagsCloudContainer.ConsoleUi.Handlers.Interfaces;
using TagsCloudContainer.ConsoleUi.Options;

namespace TagsCloudContainer.ConsoleUi.Handlers;

public class ExitHandler : IHandler<ExitOptions>
{
    public string Execute(ExitOptions options)
    {
        Environment.Exit(0);
        return "Завершение";
    }
}