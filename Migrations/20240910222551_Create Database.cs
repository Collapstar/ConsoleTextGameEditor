using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JogoTexto3.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NorthExitId = table.Column<int>(type: "int", nullable: true),
                    SouthExitId = table.Column<int>(type: "int", nullable: true),
                    WestExitId = table.Column<int>(type: "int", nullable: true),
                    EastExitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Rooms_EastExitId",
                        column: x => x.EastExitId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_Rooms_NorthExitId",
                        column: x => x.NorthExitId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_Rooms_SouthExitId",
                        column: x => x.SouthExitId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_Rooms_WestExitId",
                        column: x => x.WestExitId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Rooms_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_LocationId",
                table: "Players",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_EastExitId",
                table: "Rooms",
                column: "EastExitId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_NorthExitId",
                table: "Rooms",
                column: "NorthExitId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_SouthExitId",
                table: "Rooms",
                column: "SouthExitId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_WestExitId",
                table: "Rooms",
                column: "WestExitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
