using Microsoft.EntityFrameworkCore;
using Publications.DAL.Entities;

namespace Publications.DAL.Context
{
    public class PublicationsDB : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Publication> Publications { get; set; }

        public DbSet<PublicationPlace> PublicationPlace { get; set; }

        public PublicationsDB(DbContextOptions<PublicationsDB> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

        }
    }
}
