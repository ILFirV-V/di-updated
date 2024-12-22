using System.Drawing.Imaging;

namespace TagsCloudContainer.TagsCloudVisualization.Models.Settings;

public record FileSettings
{
    public string InputPath { get; set; } = string.Empty;
    public string OutputPath { get; set; } = string.Empty;
    public string OutputFileName { get; set; } = string.Empty;
    public ImageFormat ImageFormat { get; init; } = ImageFormat.Png;
}