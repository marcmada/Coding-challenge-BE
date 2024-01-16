using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoddingChallenge.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTablesStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Robot_Teams_TeamId",
                table: "Robot");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Captain_CaptainId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Robot",
                table: "Robot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Captain",
                table: "Captain");

            migrationBuilder.RenameTable(
                name: "Robot",
                newName: "Robots");

            migrationBuilder.RenameTable(
                name: "Captain",
                newName: "Captains");

            migrationBuilder.RenameIndex(
                name: "IX_Robot_TeamId",
                table: "Robots",
                newName: "IX_Robots_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Robots",
                table: "Robots",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Captains",
                table: "Captains",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Robots_Teams_TeamId",
                table: "Robots",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Captains_CaptainId",
                table: "Teams",
                column: "CaptainId",
                principalTable: "Captains",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Robots_Teams_TeamId",
                table: "Robots");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Captains_CaptainId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Robots",
                table: "Robots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Captains",
                table: "Captains");

            migrationBuilder.RenameTable(
                name: "Robots",
                newName: "Robot");

            migrationBuilder.RenameTable(
                name: "Captains",
                newName: "Captain");

            migrationBuilder.RenameIndex(
                name: "IX_Robots_TeamId",
                table: "Robot",
                newName: "IX_Robot_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Robot",
                table: "Robot",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Captain",
                table: "Captain",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Robot_Teams_TeamId",
                table: "Robot",
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
    }
}
