using TagsCloudContainer.ConsoleUi.Handlers.Interfaces;
using TagsCloudContainer.ConsoleUi.Options;
using TagsCloudContainer.TagsCloudVisualization.Providers.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Handlers;

public class FileSettingsHandler(IFileSettingsProvider settingsProvider)
    : IHandler<FileSettingsOptions>
{
    public string Execute(FileSettingsOptions settingsOptions)
    {
        SetFileSettings(settingsOptions);
        return "Настройки изменены";
    }

    private void SetFileSettings(FileSettingsOptions settingsOptions)
    {
        var currentSettings = settingsProvider.GetPathSettings();
        if (!string.IsNullOrEmpty(settingsOptions.ImageFormatString) &&
            !Equals(settingsOptions.ImageFormat, currentSettings.ImageFormat))
        {
            settingsProvider.SetImageFormat(settingsOptions.ImageFormat);
        }

        if (!string.IsNullOrEmpty(settingsOptions.InputPath)
            && !Equals(settingsOptions.InputPath, currentSettings.InputPath))
        {
            settingsProvider.SetInputPath(settingsOptions.InputPath);
        }

        if (!string.IsNullOrEmpty(settingsOptions.OutputPath)
            && !Equals(settingsOptions.OutputPath, currentSettings.OutputPath))
        {
            settingsProvider.SetOutputPath(settingsOptions.OutputPath);
        }

        if (!string.IsNullOrEmpty(settingsOptions.OutputFileName) &&
            !Equals(settingsOptions.OutputFileName, currentSettings.OutputFileName))
        {
            settingsProvider.SetOutputFileName(settingsOptions.OutputFileName);
        }
    }
}