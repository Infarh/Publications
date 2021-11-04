using System.Collections.Generic;
using Publications.Interfaces.Base.Repositories;

namespace Publications.DAL.Repositories
{
    /// <summary>Страница</summary>
    /// <typeparam name="T">Тип элементов страницы</typeparam>
    internal record Page<T>(IEnumerable<T> Items, int ItemsCount, int TotalCount, int PageNumber, int PageSize) : IPage<T>;
}
