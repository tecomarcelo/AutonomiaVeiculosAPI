using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutonomiaVeiculosAPI.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InclusãoCustoAbastecimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FuelingCosts",
                table: "Fuelings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelingCosts",
                table: "Fuelings");
        }
    }
}
