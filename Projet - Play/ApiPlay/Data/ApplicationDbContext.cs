using ApiPlay.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPlay.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Joueur> Joueurs { get; set; }
        public DbSet<Jeux> Jeuxs { get; set; }
        public DbSet<JoueurJeux> JoueurJeuxs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Joueur>()
                        .HasMany(e => e.Jeuxs)
                        .WithMany(e => e.Joueurs)
                        .UsingEntity<JoueurJeux>();

            /*modelBuilder.Entity<Jeux>()
                        .HasMany(e => e.Joueurs)
                        .WithMany(e => e.Jeuxs)
                        .UsingEntity<JoueurJeux>();*/

            modelBuilder.Entity<Joueur>().HasData(InitialData.listeJoueurs);
            modelBuilder.Entity<Jeux>().HasData(InitialData.listeJeux);
            modelBuilder.Entity<JoueurJeux>().HasData(InitialData.listeJoueurJeux);

        }
    }
}
