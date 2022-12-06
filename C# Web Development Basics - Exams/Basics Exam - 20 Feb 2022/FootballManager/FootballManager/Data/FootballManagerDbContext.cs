namespace FootballManager.Data
{
    using FootballManager.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class FootballManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; init; }
        public DbSet<Player> Players { get; init; }

        public DbSet<UserPlayer> UserPlayers { get; init; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FootballManager;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPlayer>()
                .HasKey(up => new { up.UserId, up.PlayerId });
            modelBuilder.Entity<Player>()
                .HasMany(p=>p.UserPlayers)
                .WithOne(p => p.Player)
                .HasForeignKey(p=>p.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasMany(u=>u.UserPlayers)
                .WithOne(up=>up.User)
                .HasForeignKey(u=>u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}