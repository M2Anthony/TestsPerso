using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPlay.Models
{
    public class JoueurJeux
    {
        [ForeignKey(nameof(Joueur))]
        public int JoueurId { get; set; }

        [ForeignKey(nameof(Jeux))]
        public int JeuxId { get; set; }

        public Joueur? Joueur { get; set; }
        public Jeux? Jeux { get; set; }
    }
}
