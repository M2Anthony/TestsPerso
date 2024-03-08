using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPlay.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jeuxs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheminJaquette = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jeuxs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Joueurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pseudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    CheminAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JoueurJeuxs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JoueurId = table.Column<int>(type: "int", nullable: false),
                    JeuxId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoueurJeuxs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JoueurJeuxs_Jeuxs_JeuxId",
                        column: x => x.JeuxId,
                        principalTable: "Jeuxs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JoueurJeuxs_Joueurs_JoueurId",
                        column: x => x.JoueurId,
                        principalTable: "Joueurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Jeuxs",
                columns: new[] { "Id", "CheminJaquette", "Description", "Titre" },
                values: new object[,]
                {
                    { 1, "Images/jaquette_elden_ring", "Un jeu FromSoftware", "Elden Ring" },
                    { 2, "Images/jaquette_kena_bridge_of_spirits", "Un jeu Ember Labs", "Kena: Bridge of Spirits" }
                });

            migrationBuilder.InsertData(
                table: "Joueurs",
                columns: new[] { "Id", "Age", "CheminAvatar", "Pseudo" },
                values: new object[,]
                {
                    { 1, 29, "Images/avatar_anthony", "Anthony" },
                    { 2, 27, "Images/avatar_tanya", "Tanya" }
                });

            migrationBuilder.InsertData(
                table: "JoueurJeuxs",
                columns: new[] { "Id", "JeuxId", "JoueurId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "JoueurJeuxs",
                columns: new[] { "Id", "JeuxId", "JoueurId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_JoueurJeuxs_JeuxId",
                table: "JoueurJeuxs",
                column: "JeuxId");

            migrationBuilder.CreateIndex(
                name: "IX_JoueurJeuxs_JoueurId",
                table: "JoueurJeuxs",
                column: "JoueurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JoueurJeuxs");

            migrationBuilder.DropTable(
                name: "Jeuxs");

            migrationBuilder.DropTable(
                name: "Joueurs");
        }
    }
}
