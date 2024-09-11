using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JogoTexto3.Models {
	public class Room {
		public int Id { get; set; }
		[StringLength(100)]
		public string Name { get; set; }
		public string Description { get; set; }
		public static List<Room> rooms = new List<Room>();

		[ForeignKey("NorthExitId")]
		public Room? NorthExit { get; set; } = null;

		[ForeignKey("SouthExitId")]
		public Room? SouthExit { get; set; } = null;

		[ForeignKey("WestExitId")]
		public Room? WestExit { get; set; } = null;

		[ForeignKey("EastExitId")]
		public Room? EastExit { get; set; } = null;

		/*
		[NotMapped]
		public Dictionary<int, Room?> Exits { get; set; } = new Dictionary<int, Room?>();

		public void SetExit(int key, Room? value) {
			if (Exits.ContainsKey(key)) {
				Exits[key] = value;
				if (key == 1) NorthExit = value;
				if (key == -1) SouthExit = value;
				if (key == 2) WestExit = value;
				if (key == -2) EastExit = value;
			} else {
				Exits.Add(key, value);
			}
		}

		public Room? GetExit(int key) {
			Room? result = null;
			if (Exits.ContainsKey(key)) {
				result = Exits[key];
			}
			return result;
		}
		*/

		public Room(string name, string description) {
			Name = name;
			Description = description;
			rooms.Add(this);
		}

		/*
		public void SetBidirectionalExit(int direction, Room room) {
			foreach (var key in Exits.Keys) {
				if (key == direction) {
					SetExit(key, room);
					int oppositeKey = key * -1;
					room.SetExit(oppositeKey, this); // get the opposite direction
				}
			}
		}
		*/

		public void SetBidirectionalExit(string direction, Room room) {
			if (direction == "n") {
				NorthExit = room;
				room.SouthExit = this;
			} else if (direction == "s") {
				SouthExit = room;
				room.NorthExit = this;
			} else if (direction == "w") {
				WestExit = room;
				room.EastExit = this;
			} else if (direction == "e") {
				EastExit = room;
				room.WestExit = this;
			}
		}

		public string ShowCompleteDescription() {
			return $"== {Name} ==\n\n{Description}";
		}

	}
}
