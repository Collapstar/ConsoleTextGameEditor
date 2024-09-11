using System.ComponentModel.DataAnnotations;
using JogoTexto3.View;

namespace JogoTexto3.Models
{
    public class Character {
		public int Id { get; set; }
		[StringLength(100)]
		public string Name { get; set; }
		public string Description { get; set; }
		public int Level { get; set; }
		public Room Location { get; set; }

		public Character(string name, string description, int level) {
			Name = name;
			Description = description;
			Level = level;
		}
	}
}
