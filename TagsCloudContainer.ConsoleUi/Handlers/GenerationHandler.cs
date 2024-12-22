using TagsCloudContainer.ConsoleUi.Handlers.Interfaces;
using TagsCloudContainer.ConsoleUi.Options;
using TagsCloudContainer.TagsCloudVisualization.Logic.Visualizers.Interfaces;
using TagsCloudContainer.TagsCloudVisualization.Providers.Interfaces;
using TagsCloudContainer.TextAnalyzer.Logic.Preprocessors.Interfaces;
using TagsCloudContainer.TextAnalyzer.Logic.Readers.Interfaces;
using TagsCloudContainer.TextAnalyzer.Providers.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Handlers;

public class GenerationHandler(
    IFileTextReader fileReader,
    ITextPreprocessor textPreprocessor,
    IWordsCloudVisualizer wordsCloudVisualizer,
    IFileSettingsProvider fileSettingsProvider,
    IImageSettingsProvider imageSettingsProvider,
    IWordSettingsProvider wordSettingsProvider) : IHandler<GenerationOptions>
{
    public string Execute(GenerationOptions options)
    {
        GenerateFile();
        return "Сгенерирован файл";
    }

    private void GenerateFile()
    {
        var pathSettings = fileSettingsProvider.GetPathSettings();
        var imageSettings = imageSettingsProvider.GetImageSettings();
        var wordSettings = wordSettingsProvider.GetWordSettings();
        var text = fileReader.ReadText(pathSettings.InputPath);
        var analyzeWords = textPreprocessor.GetWordFrequencies(text, wordSettings);
        using var image = wordsCloudVisualizer.CreateImage(imageSettings, analyzeWords);
        wordsCloudVisualizer.SaveImage(image, pathSettings);
    }
}