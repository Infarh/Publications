using System;

namespace Publications.BlazorUI.Hosting.Models.DTO
{
    public abstract class DTOTimedEntity : DTOModel
    {
        public DateTimeOffset Time { get; set; }
    }
}
