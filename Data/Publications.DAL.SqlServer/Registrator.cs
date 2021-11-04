using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Publications.DAL.Context;
using Publications.DAL.Repositories;

namespace Publications.DAL.SqlServer
{
    /// <summary>Регистратор сервисов слоя данных для SQL-сервера</summary>
    public static class Registrator
    {
        /// <summary>Добавить контекст данных в контейнер сервисов для подключения к SQL-серверу</summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="ConnectionString">Строка подключения к серверу</param>
        /// <returns>Коллекция сервисов</returns>
        public static IServiceCollection AddPublicationsDbContextSqlServer(this IServiceCollection services, string ConnectionString) =>
            services
               .AddDbContext<PublicationsDB>(opt => opt.UseSqlServer(ConnectionString, o => o.MigrationsAssembly(typeof(Registrator).Assembly.FullName)))
               .AddScoped<IDbInitializer, PublicationsDBInitializer>()
               .AddPublicationsRepositories();

        /// <summary>Добавить фабрику контекста данных в контейнер сервисов для подключения к SQL-серверу</summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="ConnectionString">Строка подключения к серверу</param>
        /// <returns>Коллекция сервисов</returns>
        public static IServiceCollection AddPublicationsDbContextFactorySqlServer(this IServiceCollection services, string ConnectionString) =>
            services
               .AddDbContextFactory<PublicationsDB>(opt => opt.UseSqlServer(ConnectionString, o => o.MigrationsAssembly(typeof(Registrator).Assembly.FullName)))
               .AddScoped<IDbInitializer, PublicationsDBInitializer>()
               .AddPublicationsRepositoryFactories();
    }
}
