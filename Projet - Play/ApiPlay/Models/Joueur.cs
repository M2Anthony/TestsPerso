namespace ApiPlay.Models
{
    public class Joueur
    {
        public int Id { get; set; }

        public string Pseudo { get; set; }

        public int? Age { get; set; }

        public string? CheminAvatar { get; set; }

        public ICollection<JoueurJeux>? JoueurJeuxs { get; set; }
    }
}
