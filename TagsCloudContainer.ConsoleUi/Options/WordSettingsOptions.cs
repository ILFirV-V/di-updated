using CommandLine;
using TagsCloudContainer.ConsoleUi.Options.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Options;

[Verb("words", HelpText = "Настройки анализа слов")]
public class WordSettingsOptions : IOptions
{
    [Option('v', "valid", HelpText = "Валидные части речи(V - гл, S - сущ, A - прил, ADV - наречие, NUM - числ). Больше тут: `https://yandex.ru/dev/mystem/doc/ru/grammemes-values`")]
    public ICollection<string> ValidSpeechParts { get; set; } = new List<string>();
}