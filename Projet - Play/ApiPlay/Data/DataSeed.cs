using ApiPlay.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPlay.Data
{
    public class DataSeed
    {
        private readonly ApplicationDbContext _dbContext;
        public DataSeed(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DataSeedDbContext()
        {
            var joueursJeuxs = new List<JoueurJeux>()
                {
                    new JoueurJeux()
                    {

                    Joueur = new Joueur()
                        {
                        Id = 1,
                        Pseudo = "Anthony",
                        Age = 29,
                        CheminAvatar = "Images/avatar_anthony"
                    },
                    Jeux = new Jeux()
                    {
                        Id = 1,
                        Titre = "Elden Ring",
                        Description = "Un jeu FromSoftware",
                        CheminJaquette = "Images/jaquette_elden_ring"
                    }
                },
                new JoueurJeux()
                {
                    Joueur = new Joueur()
                    {
                        Id = 2,
                        Pseudo = "Tanya",
                        Age = 27,
                        CheminAvatar = "Images/avatar_tanya"
                    },
                    Jeux = new Jeux()
                    {
                        Id = 2,
                        Titre = "Kena: Bridge of Spirits",
                        Description = "Un jeu Ember Lab",
                        CheminJaquette = "Images/jaquette_kena_bridge_of_spirits"
                    }
                }
        };
            _dbContext.JoueurJeuxs.AddRange(joueursJeuxs);
            _dbContext.SaveChanges();

        }
    }
}
