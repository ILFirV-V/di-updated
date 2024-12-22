using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using TagsCloudContainer.ConsoleUi;
using TagsCloudContainer.ConsoleUi.Runner.Interfaces;
using TagsCloudContainer.TagsCloudVisualization.Extensions;
using TagsCloudContainer.TextAnalyzer.Extensions;

var services = new ServiceCollection();
services.AddTextAnalyzerServices();
services.AddTagsCloudVisualization();

var builder = new ContainerBuilder();
builder.Populate(services);
builder.RegisterModule(new ConsoleClientModule());

var app = builder.Build();
using var scope = app.BeginLifetimeScope();
var appRunner = scope.Resolve<ITagsCloudContainerUi>();
appRunner.Run();