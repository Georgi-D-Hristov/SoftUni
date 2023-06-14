namespace Panda.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Panda.Web.Data.Models;

    public class PandaDbContext : IdentityDbContext<User>
    {
        //public DbSet<User> Users { get; init; }

        public DbSet<Package> Packages { get; init; }

        public DbSet<Receipt> Receipts { get; init; }

        public PandaDbContext(DbContextOptions<PandaDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}