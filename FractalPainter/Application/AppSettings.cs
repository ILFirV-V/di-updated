using FractalPainting.Infrastructure.Common;

namespace FractalPainting.Application;

public class AppSettings : IImageSettingsProvider
{
    public ImageSettings ImageSettings { get; init; }

    public AppSettings(ImageSettings imageSettings)
    {
        ImageSettings = imageSettings;
    }
}