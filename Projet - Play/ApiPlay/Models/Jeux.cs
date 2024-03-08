using System.ComponentModel.DataAnnotations;

namespace ApiPlay.Models
{
    public class Jeux
    {
        public int Id { get; set; }

        [Required]
        public string Titre { get; set; }

        public string? Description { get; set; }

        public string? CheminJaquette { get; set; }

        public List<Joueur>? Joueurs { get; set; } = new List<Joueur>();

        public List<JoueurJeux>? JoueurJeuxs { get; set; } = new List<JoueurJeux>();
    }
}
