using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Publications.DAL.Context;

namespace Publications.DAL
{
    public static class ServicesExtensions
    {
        /// <summary>Получить контекст БД</summary>
        /// <param name="services">Провайдер сервисов</param>
        /// <returns>Контекст БД</returns>
        public static PublicationsDB GetPublicationsDB(this IServiceProvider services) => services.GetRequiredService<PublicationsDB>();

        /// <summary>Получить фабрику контекстов БД</summary>
        /// <param name="services">Провайдер сервисов</param>
        /// <returns>Фабрика контекстов БД</returns>
        public static IDbContextFactory<PublicationsDB> GetPublicationsDBFactory(this IServiceProvider services) =>
            services.GetRequiredService<IDbContextFactory<PublicationsDB>>();

        /// <summary>Получить контекст БД</summary>
        /// <param name="scope">Область видимости провайдера сервисов</param>
        /// <returns>Контекст БД</returns>
        public static PublicationsDB GetPublicationsDB(this IServiceScope scope) => scope.ServiceProvider.GetPublicationsDB();

        /// <summary>Получить фабрику контекстов БД</summary>
        /// <param name="scope">Область видимости провайдера сервисов</param>
        /// <returns>Фабрика контекстов БД</returns>
        public static IDbContextFactory<PublicationsDB> GetPublicationsDBFactory(this IServiceScope scope) => scope.ServiceProvider.GetPublicationsDBFactory();
    }
}
