using AutoSzerelo.UI.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace AutoSzerelo.UI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:8080") });
		builder.Services.AddScoped<IKliensSzolgaltatas, KliensSzolgaltatas>();
		builder.Services.AddScoped<IMunkaSzolgaltatas, MunkaSzolgaltatas>();

        await builder.Build().RunAsync();
    }
}
