namespace ApiPlay.Models
{
    public class JoueurJeux
    {
        public int JoueurId { get; set; }
        public int JeuxId { get; set; }

        public Joueur? Joueur { get; set; }
        public Jeux? Jeux { get; set; }
    }
}
