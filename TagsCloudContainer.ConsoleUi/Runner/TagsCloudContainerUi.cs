using CommandLine;
using TagsCloudContainer.ConsoleUi.Handlers.Interfaces;
using TagsCloudContainer.ConsoleUi.Options;
using TagsCloudContainer.ConsoleUi.Options.Interfaces;
using TagsCloudContainer.ConsoleUi.Runner.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Runner;

public class TagsCloudContainerUi(
    IEnumerable<IOptions> options,
    IHandler<ExitOptions> exitHandler,
    IHandler<FileSettingsOptions> fileSettingsHandler,
    IHandler<GenerationOptions> generationHandler,
    IHandler<ImageSettingsOptions> imageSettingHandler,
    IHandler<WordSettingsOptions> wordSettingsHandler)
    : ITagsCloudContainerUi
{
    public void Run()
    {
        var types = options.Select(x => x.GetType()).ToArray();
        Console.WriteLine("Посмотреть доступные команды \"--help\"");
        while (true)
        {
            var input = Console.ReadLine();
            var args = input?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? [];

            var resultMessage = Parser.Default.ParseArguments(args, types)
                .MapResult(
                    (ExitOptions opts) => exitHandler.Execute(opts),
                    (FileSettingsOptions opts) => fileSettingsHandler.Execute(opts),
                    (GenerationOptions opts) => generationHandler.Execute(opts),
                    (ImageSettingsOptions opts) => imageSettingHandler.Execute(opts),
                    (WordSettingsOptions opts) => wordSettingsHandler.Execute(opts),
                    _ => "Не найдена такая команда для настройки или генерации изображения");
            Console.WriteLine(resultMessage);
        }
    }
}