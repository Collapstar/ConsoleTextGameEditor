using JogoTexto3.Models;
using Microsoft.EntityFrameworkCore;
using static JogoTexto3.Erro;

namespace JogoTexto3.View {
	public class ConsoleView {
		static void Main(string[] args) {
			Player? player;

			using (var db = new JogoDbContext()) {
				// Carregar o jogador salvo no banco de dados, incluindo a localização (sala)
				player = db.Players
					.FirstOrDefault();

				db.Rooms
					.Load();

				// Se o jogador não existir, criar um novo jogador e a sala inicial
				if (player == null) {
					Room initialRoom = new Room("Início", "Bem-vindo.");
					player = new Player("Salem", "Um ladrão esperto.", 1);
					player.Location = initialRoom;

					// Salvar o novo jogador e sala no banco de dados
					db.Rooms.Add(initialRoom);
					db.Players.Add(player);
					db.SaveChanges();
				}
			}

			// Mostrar a sala atual do jogador
			player.LookRoom();
			Console.WriteLine();

			// 3. Loop principal do jogo
			do {
				Console.Write("> ");
				string command = Console.ReadLine().ToLower();
				if (command == "exit") break;
				switch (command) {
					case "l":
					case "look": player.LookRoom(); break;
					case "n":
					case "north": player.MoveTo("n"); break;
					case "s":
					case "south": player.MoveTo("s"); break;
					case "w":
					case "west": player.MoveTo("w"); break;
					case "e":
					case "east": player.MoveTo("e"); break;
					case "c n": player.CreateRoomAhead("n"); break;
					case "c s": player.CreateRoomAhead("s"); break;
					case "c w": player.CreateRoomAhead("w"); break;
					case "c e": player.CreateRoomAhead("e"); break;
					case "rename":
						Console.Write("Insira o novo nome: ");
						string newName = Console.ReadLine();
						player.RenameRoom(newName);
						Console.WriteLine($"Sala renomeada para {newName}");
						break;
					case "describe":
						Console.Write("Insira uma nova descrição: ");
						string newDescription = Console.ReadLine();
						player.RedescribeRoom(newDescription);
						Console.WriteLine("Nova descrição inserida com sucesso!");
						break;
					default: Console.WriteLine(_NONEXISTENT_COMMAND); break;
				}
				Console.WriteLine();
			} while (true);

			// 4. Salvar o jogador ao sair
			Console.WriteLine("Você saiu do jogo. Aperte qualquer tecla para salvar e sair.");
			using (var db = new JogoDbContext()) {
				db.Players.Update(player);
				foreach (var room in db.Rooms) {
					db.Rooms.Update(room);
				}
				db.SaveChanges();
			}

			Console.ReadKey();
		}
	}
}