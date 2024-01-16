using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoddingChallenge.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Roles_RoleId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Teams",
                newName: "CaptainId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teams",
                newName: "TeamName");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_RoleId",
                table: "Teams",
                newName: "IX_Teams_CaptainId");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Planets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Captain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Captain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Robot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Robot_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TeamId",
                table: "Planets",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Robot_TeamId",
                table: "Robot",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_Teams_TeamId",
                table: "Planets",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Captain_CaptainId",
                table: "Teams",
                column: "CaptainId",
                principalTable: "Captain",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planets_Teams_TeamId",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Captain_CaptainId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Captain");

            migrationBuilder.DropTable(
                name: "Robot");

            migrationBuilder.DropIndex(
                name: "IX_Planets_TeamId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Planets");

            migrationBuilder.RenameColumn(
                name: "TeamName",
                table: "Teams",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CaptainId",
                table: "Teams",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_CaptainId",
                table: "Teams",
                newName: "IX_Teams_RoleId");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Roles_RoleId",
                table: "Teams",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
