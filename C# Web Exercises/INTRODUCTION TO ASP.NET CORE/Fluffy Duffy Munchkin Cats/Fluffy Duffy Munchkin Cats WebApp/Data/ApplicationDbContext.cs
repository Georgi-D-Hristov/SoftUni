namespace Fluffy_Duffy_Munchkin_Cats_WebApp.Data
{
    using Fluffy_Duffy_Munchkin_Cats_WebApp.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Cat> Cat { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null) 
            {
                optionsBuilder.UseSqlServer();
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}