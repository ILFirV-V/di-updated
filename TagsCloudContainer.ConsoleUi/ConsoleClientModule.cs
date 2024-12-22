using Autofac;
using TagsCloudContainer.ConsoleUi.Handlers;
using TagsCloudContainer.ConsoleUi.Handlers.Interfaces;
using TagsCloudContainer.ConsoleUi.Options;
using TagsCloudContainer.ConsoleUi.Options.Interfaces;
using TagsCloudContainer.ConsoleUi.Runner;
using TagsCloudContainer.ConsoleUi.Runner.Interfaces;

namespace TagsCloudContainer.ConsoleUi;

public class ConsoleClientModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TagsCloudContainerUi>().As<ITagsCloudContainerUi>();
        builder.RegisterType<ExitHandler>().As<IHandler<ExitOptions>>();
        builder.RegisterType<WordSettingsHandler>().As<IHandler<WordSettingsOptions>>();
        builder.RegisterType<ImageSettingHandler>().As<IHandler<ImageSettingsOptions>>();
        builder.RegisterType<FileSettingsHandler>().As<IHandler<FileSettingsOptions>>();
        builder.RegisterType<GenerationHandler>().As<IHandler<GenerationOptions>>();
        builder.RegisterType<ExitOptions>().As<IOptions>();
        builder.RegisterType<GenerationOptions>().As<IOptions>();
        builder.RegisterType<ImageSettingsOptions>().As<IOptions>();
        builder.RegisterType<FileSettingsOptions>().As<IOptions>();
        builder.RegisterType<WordSettingsOptions>().As<IOptions>();
    }
}