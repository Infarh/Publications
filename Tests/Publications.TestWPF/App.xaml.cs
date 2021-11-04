using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Publications.DAL.Sqlite;
using Publications.DAL.SqlServer;

namespace Publications.TestWPF
{
    public partial class App
    {
        static App() => ConfigureServices += OnConfigureServices;

        private static void OnConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            var db_type = host.Configuration["Database"];
            switch (db_type)
            {
                default: throw new NotSupportedException($"Тип БД {db_type} не поддерживается");

                case "SqlServer":
                    services.AddPublicationsDbContextFactorySqlServer(host.Configuration.GetConnectionString(db_type));
                    break;

                case "Sqlite":
                    services.AddPublicationsDbContextFactorySqlite(host.Configuration.GetConnectionString(db_type));
                    break;
            }
        }
    }
}
