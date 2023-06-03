using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoCaixa.Migrations
{
    /// <inheritdoc />
    public partial class AjusteSchemaOfSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorUnitario",
                table: "ItemVendas");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "ItemVendas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Preco",
                table: "ItemVendas",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "ItemVendas");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "ItemVendas");

            migrationBuilder.AddColumn<double>(
                name: "ValorUnitario",
                table: "ItemVendas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
