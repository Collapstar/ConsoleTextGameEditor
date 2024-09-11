using System.Numerics;
using static JogoTexto3.Erro;

namespace JogoTexto3.Models {
	public class Player : Character {
		public Player(string name, string description, int level) : base(name, description, level) {
		}

		public void LookRoom() => Console.WriteLine(Location.ShowCompleteDescription());

		public void MoveTo(string direction) {
			if (Location == null) {
				Console.WriteLine("Error: You are not in any location.");
				return;
			}

			Room? targetRoom = null;

			if (direction == "n") targetRoom = Location.NorthExit;
			else if (direction == "s") targetRoom = Location.SouthExit;
			else if (direction == "w") targetRoom = Location.WestExit;
			else if (direction == "e") targetRoom = Location.EastExit;

			if (targetRoom != null) {
				Location = targetRoom;
				Console.WriteLine(targetRoom.ShowCompleteDescription());
			} else {
				Console.WriteLine(_PATH_UNAVAILABLE);
			}
		}

		public void CreateRoomAhead(string direction, string nome = "Nova Sala", string descricao = "Insira uma descrição.") {
			if (direction == "n") {
				if (Location.NorthExit != null) {
					Console.WriteLine(_OCCUPIED_DIRECTION);
				} else {
					Room newRoom = new Room(nome, descricao);
					using (var db = new JogoDbContext()) {
						db.Rooms.Add(newRoom);
						db.Rooms.Update(Location);
						db.SaveChanges();
					}
					Location.SetBidirectionalExit("n", newRoom);
					using (var db = new JogoDbContext()) {
						// Atualize tanto a sala atual quanto a nova com as saídas
						db.Rooms.Update(Location);
						db.Rooms.Update(newRoom);
						db.SaveChanges(); // Salva novamente com as saídas configuradas
					}
					MoveTo("n");
				}
			} else if (direction == "s") {
				if (Location.SouthExit != null) {
					Console.WriteLine(_OCCUPIED_DIRECTION);
				} else {
					Room newRoom = new Room(nome, descricao);
					using (var db = new JogoDbContext()) {
						db.Rooms.Add(newRoom);
						db.Rooms.Update(Location);
						db.SaveChanges();
					}
					Location.SetBidirectionalExit("s", newRoom);
					using (var db = new JogoDbContext()) {
						// Atualize tanto a sala atual quanto a nova com as saídas
						db.Rooms.Update(Location);
						db.Rooms.Update(newRoom);
						db.SaveChanges(); // Salva novamente com as saídas configuradas
					}
					MoveTo("s");
				}
			} else if (direction == "w") {
				if (Location.WestExit != null) {
					Console.WriteLine(_OCCUPIED_DIRECTION);
				} else {
					Room newRoom = new Room(nome, descricao);
					using (var db = new JogoDbContext()) {
						db.Rooms.Add(newRoom);
						db.Rooms.Update(Location);
						db.SaveChanges();
					}
					Location.SetBidirectionalExit("w", newRoom);
					using (var db = new JogoDbContext()) {
						// Atualize tanto a sala atual quanto a nova com as saídas
						db.Rooms.Update(Location);
						db.Rooms.Update(newRoom);
						db.SaveChanges(); // Salva novamente com as saídas configuradas
					}
					MoveTo("w");
				}
			} else if (direction == "e") {
				if (Location.EastExit != null) {
					Console.WriteLine(_OCCUPIED_DIRECTION);
				} else {
					Room newRoom = new Room(nome, descricao);
					using (var db = new JogoDbContext()) {
						db.Rooms.Add(newRoom);
						db.Rooms.Update(Location);
						db.SaveChanges();
					}
					Location.SetBidirectionalExit("e", newRoom);
					using (var db = new JogoDbContext()) {
						// Atualize tanto a sala atual quanto a nova com as saídas
						db.Rooms.Update(Location);
						db.Rooms.Update(newRoom);
						db.SaveChanges(); // Salva novamente com as saídas configuradas
					}
					MoveTo("e");
				}
			}
		}


		public void RenameRoom(string newName) => Location.Name = newName;

		public void RedescribeRoom(string newDescription) => Location.Description = newDescription;

	}
}
