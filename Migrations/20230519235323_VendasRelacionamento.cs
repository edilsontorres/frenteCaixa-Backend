using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoCaixa.Migrations
{
    /// <inheritdoc />
    public partial class VendasRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendasIdProduct",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendasIdVenda",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItensVendas",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    IdVenda = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVendas", x => new { x.IdVenda, x.IdProduct });
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotal = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ItensVendaIdVenda = table.Column<int>(type: "int", nullable: true),
                    ItensVendaIdProduct = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_ItensVendas_ItensVendaIdVenda_ItensVendaIdProduct",
                        columns: x => new { x.ItensVendaIdVenda, x.ItensVendaIdProduct },
                        principalTable: "ItensVendas",
                        principalColumns: new[] { "IdVenda", "IdProduct" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_VendasIdVenda_VendasIdProduct",
                table: "Products",
                columns: new[] { "VendasIdVenda", "VendasIdProduct" });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ItensVendaIdVenda_ItensVendaIdProduct",
                table: "Vendas",
                columns: new[] { "ItensVendaIdVenda", "ItensVendaIdProduct" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ItensVendas_VendasIdVenda_VendasIdProduct",
                table: "Products",
                columns: new[] { "VendasIdVenda", "VendasIdProduct" },
                principalTable: "ItensVendas",
                principalColumns: new[] { "IdVenda", "IdProduct" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ItensVendas_VendasIdVenda_VendasIdProduct",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "ItensVendas");

            migrationBuilder.DropIndex(
                name: "IX_Products_VendasIdVenda_VendasIdProduct",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VendasIdProduct",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VendasIdVenda",
                table: "Products");
        }
    }
}
