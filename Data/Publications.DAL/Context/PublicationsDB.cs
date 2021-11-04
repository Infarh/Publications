using Microsoft.EntityFrameworkCore;

namespace Publications.DAL.Context
{
    public class PublicationsDB : DbContext
    {
        public PublicationsDB(DbContextOptions<PublicationsDB> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

        }
    }
}
