using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoddingChallenge.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Captains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Captains",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Captains");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Captains");
        }
    }
}
