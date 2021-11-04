using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Publications.DAL.Context;
using Publications.DAL.Repositories;

namespace Publications.DAL.Sqlite
{
    /// <summary>Регистратор сервисов слоя данных для Sqlite</summary>
    public static class Registrator
    {
        /// <summary>Добавить контекст данных в контейнер сервисов для подключения к Sqlite</summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="ConnectionString">Строка подключения к серверу</param>
        /// <returns>Коллекция сервисов</returns>
        public static IServiceCollection AddPublicationsDbContextSqlite(this IServiceCollection services, string ConnectionString) => 
            services
               .AddDbContext<PublicationsDB>(opt => opt.UseSqlite(ConnectionString, o => o.MigrationsAssembly(typeof(Registrator).Assembly.FullName)))
               .AddScoped<IDbInitializer, PublicationsDBInitializer>()
               .AddPublicationsRepositories();

        /// <summary>Добавить фабрику контекста данных в контейнер сервисов для подключения к Sqlite</summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="ConnectionString">Строка подключения к серверу</param>
        /// <returns>Коллекция сервисов</returns>
        public static IServiceCollection AddPublicationsDbContextFactorySqlite(this IServiceCollection services, string ConnectionString) => 
            services
               .AddDbContextFactory<PublicationsDB>(opt => opt.UseSqlite(ConnectionString, o => o.MigrationsAssembly(typeof(Registrator).Assembly.FullName)))
               .AddScoped<IDbInitializer, PublicationsDBInitializer>()
               .AddPublicationsRepositoryFactories();
    }
}
