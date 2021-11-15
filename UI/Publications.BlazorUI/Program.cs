global using System;
global using System.Threading.Tasks;
global using Publications.BlazorUI;

using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Publications.BlazorUI.ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

var services = builder.Services;
services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
services.AddScoped<MainViewModel>();

await builder.Build().RunAsync();
