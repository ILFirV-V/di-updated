using TagsCloudContainer.ConsoleUi.Handlers.Interfaces;
using TagsCloudContainer.ConsoleUi.Options;
using TagsCloudContainer.TagsCloudVisualization.Providers.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Handlers;

public class ImageSettingHandler(IImageSettingsProvider imageSettingsProvider) : IHandler<ImageSettingsOptions>
{
    public string Execute(ImageSettingsOptions options)
    {
        SetSettings(options);
        return "Настройки изображения изменены";
    }

    private void SetSettings(ImageSettingsOptions options)
    {
        var currentSettings = imageSettingsProvider.GetImageSettings();
        if (options.BackgroundColor != default && !options.BackgroundColor.Equals(currentSettings.BackgroundColor))
        {
            imageSettingsProvider.SetBackgroundColor(options.BackgroundColor);
        }

        if (options.WordColor != default && !options.WordColor.Equals(currentSettings.WordColor))
        {
            imageSettingsProvider.SetWordColor(options.WordColor);
        }

        if (options.FontFamily is not null && !Equals(options.FontFamily, currentSettings.FontFamily))
        {
            imageSettingsProvider.SetFontFamily(options.FontFamily);
        }

        if (options.Height != default && !options.Height.Equals(currentSettings.Size.Height))
        {
            var newSize = currentSettings.Size with {Height = options.Height};
            imageSettingsProvider.SetSize(newSize);
        }

        if (options.Width != default && !options.Width.Equals(currentSettings.Size.Width))
        {
            var newSize = currentSettings.Size with {Width = options.Width};
            imageSettingsProvider.SetSize(newSize);
        }
    }
}