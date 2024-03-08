using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiPlay.Models
{
    public class Joueur
    {
        public int Id { get; set; }

        [Required]
        public string Pseudo { get; set; }

        [Required]
        public int? Age { get; set; }

        public string? CheminAvatar { get; set; }

        public List<Jeux>? Jeuxs { get; set; } = new List<Jeux>();

        public List<JoueurJeux>? JoueurJeuxs { get; set; } = new List<JoueurJeux>();
    }
}
