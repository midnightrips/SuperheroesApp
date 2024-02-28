using System.ComponentModel.DataAnnotations;

namespace SuperheroesApp.Models
{
    public class Superhero
    {
        //properties of the class -- determined by user stories
        [Key]
        public int Id { get; set; } //primary key
        public string Name { get; set; }
        public string AlterEgo { get; set; }
        public string PrimaryAbility { get; set; }
        public string SecondaryAbility { get; set; }
        public string Catchphrase { get; set; }
    }
}
