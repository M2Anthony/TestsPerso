using ApiPlay.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPlay.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Joueur> Joueurs { get; set; }
        DbSet<Jeux> Jeuxs { get; set; }
        DbSet<JoueurJeux> JoueurJeuxs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Joueur>().HasData(
                new Joueur
                {
                    Id = 1, Pseudo = "Anthony", Age = 29, CheminAvatar = "Images/avatar_anthony"
                });
        }
    }
}
