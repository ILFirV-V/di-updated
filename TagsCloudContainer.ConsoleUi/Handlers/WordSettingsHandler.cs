using TagsCloudContainer.ConsoleUi.Handlers.Interfaces;
using TagsCloudContainer.ConsoleUi.Options;
using TagsCloudContainer.TextAnalyzer.Providers.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Handlers;

public class WordSettingsHandler(IWordSettingsProvider wordSettingsProvider) : IHandler<WordSettingsOptions>
{
    public string Execute(WordSettingsOptions options)
    {
        SetSettings(options);
        return "Настройки изображения изменены";
    }

    private void SetSettings(WordSettingsOptions options)
    {
        var currentSettings = wordSettingsProvider.GetWordSettings();
        if (options.ValidSpeechParts.Count != 0 
            && !options.ValidSpeechParts.SequenceEqual(currentSettings.ValidSpeechParts))
        {
            wordSettingsProvider.SetValidSpeechParts(options.ValidSpeechParts);
        }
    }
}