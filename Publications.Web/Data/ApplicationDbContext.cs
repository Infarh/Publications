using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Publications.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publication> Publications { get; set; }

        public DbSet<AuthorDegree> AuthorDegrees { get; set; }
        public DbSet<AuthorGrade> AuthorGrades { get; set; }
        public DbSet<AuthorPosition> AuthorPositions { get; set; }
        public DbSet<PublicationPlace> PublicationPlaces { get; set; }
        public DbSet<PublicationType> PublicationTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<AuthorPublication>().HasMany(p => new {p.AuthorId, p.PublicationId});
            builder.Entity<AuthorPublication>()
                .HasKey(p => new {p.AuthorId, p.PublicationId});
            builder.Entity<AuthorPublication>()
                .HasOne(p => p.Author)
                .WithMany(a => a.Publications)
                .HasForeignKey(p => p.AuthorId);
            builder.Entity<AuthorPublication>()
                .HasOne(p => p.Publication)
                .WithMany(p => p.Authors)
                .HasForeignKey(p => p.PublicationId);

            var admin_role = new IdentityRole("Admin");
            var user_role = new IdentityRole("User");
            builder.Entity<IdentityRole>().HasData(admin_role, user_role);
            var admin = new IdentityUser
            {
                UserName = "Admin",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "PubWebAdmin")
            };
            builder.Entity<IdentityUser>().HasData(admin);
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = admin.Id, RoleId = admin_role.Id });
        }
    }
}
