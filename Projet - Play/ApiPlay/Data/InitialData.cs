using ApiPlay.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPlay.Data
{
    public class InitialData
    {
        public static readonly List<Joueur> listeJoueurs = new List<Joueur>()
        {
            new Joueur()
            {
                Id = 1, Pseudo = "Anthony", Age = 29, CheminAvatar = "Images/avatar_anthony"
            },
            new Joueur()
            {
                Id = 2, Pseudo = "Tanya", Age = 27, CheminAvatar = "Images/avatar_tanya"
            }
        };

        public static readonly List<Jeux> listeJeux = new List<Jeux>()
        {
            new Jeux()
            {
                Id = 1, Titre = "Elden Ring", Description = "Un jeu FromSoftware", CheminJaquette = "Images/jaquette_elden_ring"
            },
            new Jeux()
            {
                Id = 2, Titre = "Kena: Bridge of Spirits", Description = "Un jeu Ember Labs", CheminJaquette = "Images/jaquette_kena_bridge_of_spirits"
            }
        };

        public static readonly List<JoueurJeux> listeJoueurJeux = new List<JoueurJeux>()
        {
            new JoueurJeux()
            {
                Id = 1, JoueurId = 1, JeuxId = 1
            },
            new JoueurJeux()
            {
                Id = 2, JoueurId = 2, JeuxId = 2
            }
        };

    }
}
