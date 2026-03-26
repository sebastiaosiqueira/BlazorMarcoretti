

using ConsoleRazorComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();
services.AddLogging();

var serviceProvider = services.BuildServiceProvider();
var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();


await using var htmlRender = new HtmlRenderer(serviceProvider, loggerFactory);


var html = await htmlRender.Dispatcher.InvokeAsync(async () =>
{
    var output = await htmlRender.RenderComponentAsync<AnoNovo>(ParameterView.Empty);
    return output.ToHtmlString();
});

Console.WriteLine(html);

Console.ReadLine();


