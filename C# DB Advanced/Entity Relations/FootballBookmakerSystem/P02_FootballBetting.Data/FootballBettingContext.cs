namespace P02_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P02_FootballBetting.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    

    public class FootballBettingContext : DbContext

    {
        private const string ConnectionString = @"Server=.;Database=FootballBetting;Trusted_Connection=True;";

        public FootballBettingContext()
        {
        }
        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;

        public DbSet<Country> Countries { get; set; } = null!;

        public DbSet<Game> Games { get; set; } = null!;

        public DbSet<Player> Players { get; set; } = null!;

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; } = null!;

        public DbSet<Position >Positions { get; set; } = null!;

        public DbSet<Team> Teams { get; set; } = null!;

        public DbSet<Town> Towns { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => new { ps.PlayerId, ps.GameId });

            modelBuilder.Entity<PlayerStatistic>()
                .HasOne(ps => ps.Player)
                .WithMany(p => p.PlayersStatistics)
                .HasForeignKey(ps => ps.PlayerId);

            modelBuilder.Entity<PlayerStatistic>()
                .HasOne(ps => ps.Game)
                .WithMany(g => g.PlayersStatistics)
                .HasForeignKey(ps => ps.GameId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
