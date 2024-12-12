using FractalPainting.Application.Fractals;
using FractalPainting.Infrastructure.Common;

namespace FractalPainting.Application.Factories;

public class DragonPainterFactory(IImageSettingsProvider imageSettingsProvider, Palette palette) : IDragonPainterFactory
{
    public DragonPainter Create(DragonSettings settings)
    {
        return new DragonPainter(settings, palette, imageSettingsProvider);
    }
}