using CommandLine;
using TagsCloudContainer.ConsoleUi.Options.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Options;

[Verb("generate", HelpText = "Сгенерировать изображение")]
public class GenerationOptions : IOptions
{
}