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
            modelBuilder.Entity<JoueurJeux>()
                .HasKey(pc => new { pc.JoueurId, pc.JeuxId });

            modelBuilder.Entity<JoueurJeux>()
                .HasOne(jo => jo.Joueur)
                .WithMany(jj => jj.JoueurJeuxs)
                .HasForeignKey(fk => fk.JoueurId);

            modelBuilder.Entity<JoueurJeux>()
                .HasOne(jo => jo.Jeux)
                .WithMany(jj => jj.JoueurJeuxs)
                .HasForeignKey(fk => fk.JeuxId);


        }
    }
}
