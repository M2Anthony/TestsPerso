namespace ApiPlay.Models
{
    public class Jeux
    {
        public int Id { get; set; }

        public string Titre { get; set; }

        public string? Description { get; set; }

        public string? CheminJaquette { get; set; }

        public ICollection<JoueurJeux>? JoueurJeuxs { get; set; } = new List<JoueurJeux>();
    }
}
