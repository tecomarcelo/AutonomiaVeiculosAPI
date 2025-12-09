using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutonomiaVeiculosAPI.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoIdVehicleEmFueling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fuelings_Users_UserId",
                table: "Fuelings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Fuelings",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Fuelings_UserId",
                table: "Fuelings",
                newName: "IX_Fuelings_IdUser");

            migrationBuilder.AddColumn<int>(
                name: "IdVehicle",
                table: "Fuelings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Fuelings_Users_IdUser",
                table: "Fuelings",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fuelings_Users_IdUser",
                table: "Fuelings");

            migrationBuilder.DropColumn(
                name: "IdVehicle",
                table: "Fuelings");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Fuelings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Fuelings_IdUser",
                table: "Fuelings",
                newName: "IX_Fuelings_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fuelings_Users_UserId",
                table: "Fuelings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
