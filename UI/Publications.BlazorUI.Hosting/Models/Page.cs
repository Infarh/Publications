using System.Collections.Generic;
using Publications.Interfaces.Base.Repositories;

namespace Publications.BlazorUI.Hosting.Models
{
    public record Page<T>(
        IEnumerable<T> Items, 
        int ItemsCount, 
        int TotalCount, 
        int PageNumber, 
        int PageSize) 
        : IPage<T>;
}
