using System.Drawing.Imaging;
using CommandLine;
using TagsCloudContainer.ConsoleUi.Options.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Options;

[Verb("files", HelpText = "Настройки путей файлов")]
public class FileSettingsOptions : IOptions
{
    [Option('i', "input", Required = true, HelpText = "Путь к файлу текста для анализа.")]
    public string InputPath { get; set; }

    [Option('o', "output", Required = true, HelpText = "Путь к сохранению изображения.")]
    public string OutputPath { get; set; }

    [Option('n', "name", Required = true, HelpText = "Имя файла")]
    public string OutputFileName { get; set; }

    [Option('f', "format", HelpText = "Формат файла (png, jpeg, bmp, jpg.)")]
    public string ImageFormatString { get; set; }

    public ImageFormat ImageFormat
    {
        get
        {
            return ImageFormatString.ToLower() switch
            {
                "png" => ImageFormat.Png,
                "jpg" => ImageFormat.Jpeg,
                "jpeg" => ImageFormat.Jpeg,
                "bmp" => ImageFormat.Bmp,
                _ => throw new ArgumentException($"Unsupported image format: {ImageFormatString}")
            };
        }
    }
}