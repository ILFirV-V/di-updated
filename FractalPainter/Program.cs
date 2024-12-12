using System.Text.Json;
using System.Text.Json.Serialization;
using FractalPainting.Application;
using FractalPainting.Application.Actions;
using FractalPainting.Application.Factories;
using FractalPainting.Application.Fractals;
using FractalPainting.Application.Models;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<Palette>();
services.AddSingleton<SettingsManager>();

services.AddSingleton<IApiAction, KochFractalAction>();
services.AddSingleton<IApiAction, DragonFractalAction>();
services.AddSingleton<IApiAction, UpdateImageSettingsAction>();
services.AddSingleton<IApiAction, GetImageSettingsAction>();
services.AddSingleton<IApiAction, UpdatePaletteSettingsAction>();
services.AddSingleton<IApiAction, GetPaletteSettingsAction>();
services.AddSingleton<JsonConverter<Figure>, FigureJsonConverter>();
services.AddSingleton<IObjectSerializer, XmlObjectSerializer>();
services.AddSingleton<IBlobStorage, FileBlobStorage>();
services.AddSingleton<IImageSettingsProvider, AppSettings>
(
    provider =>
    {
        var settings = provider.GetService<SettingsManager>();
        return settings.Load();
    }
);
services.AddSingleton<IDragonPainterFactory, DragonPainterFactory>();
services.AddSingleton<JsonSerializerOptions>
(
    provider =>
    {
        var jsonConverter = provider.GetService<JsonConverter<Figure>>();
        return  new JsonSerializerOptions { Converters = { jsonConverter }};
    }
);
services.AddSingleton<KochPainter>();
services.AddSingleton<App>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<App>();

await app.Run();