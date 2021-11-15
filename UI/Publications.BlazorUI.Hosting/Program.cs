global using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Publications.DAL.Context;
using Publications.BlazorUI.Hosting;

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
       .UseSerilog((host, log) => log.ReadFrom.Configuration(host.Configuration))
       .ConfigureWebHostDefaults(host => host
           .UseStartup<Startup>()
        )
;

using var host = CreateHostBuilder(args).Build();
using (var scope = host.Services.CreateScope())
{
    var db_initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    await db_initializer.InitializeAsync();
}
await host.RunAsync();
