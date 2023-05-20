using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoCaixa.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionamentoVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ItensVendas_VendasIdVenda_VendasIdProduct",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_ItensVendas_ItensVendaIdVenda_ItensVendaIdProduct",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "ItensVendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_ItensVendaIdVenda_ItensVendaIdProduct",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Products_VendasIdVenda_VendasIdProduct",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ItensVendaIdProduct",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "ItensVendaIdVenda",
                table: "Vendas",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "VendasIdVenda",
                table: "Products",
                newName: "ItemVendaIdProduct");

            migrationBuilder.RenameColumn(
                name: "VendasIdProduct",
                table: "Products",
                newName: "ItemVendaId");

            migrationBuilder.CreateTable(
                name: "ItemVendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    VendaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVendas", x => new { x.Id, x.IdProduct });
                    table.ForeignKey(
                        name: "FK_ItemVendas_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_userId",
                table: "Vendas",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ItemVendaId_ItemVendaIdProduct",
                table: "Products",
                columns: new[] { "ItemVendaId", "ItemVendaIdProduct" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendas_VendaId",
                table: "ItemVendas",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ItemVendas_ItemVendaId_ItemVendaIdProduct",
                table: "Products",
                columns: new[] { "ItemVendaId", "ItemVendaIdProduct" },
                principalTable: "ItemVendas",
                principalColumns: new[] { "Id", "IdProduct" });

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Users_userId",
                table: "Vendas",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ItemVendas_ItemVendaId_ItemVendaIdProduct",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Users_userId",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "ItemVendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_userId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Products_ItemVendaId_ItemVendaIdProduct",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Vendas",
                newName: "ItensVendaIdVenda");

            migrationBuilder.RenameColumn(
                name: "ItemVendaIdProduct",
                table: "Products",
                newName: "VendasIdVenda");

            migrationBuilder.RenameColumn(
                name: "ItemVendaId",
                table: "Products",
                newName: "VendasIdProduct");

            migrationBuilder.AddColumn<int>(
                name: "ItensVendaIdProduct",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItensVendas",
                columns: table => new
                {
                    IdVenda = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVendas", x => new { x.IdVenda, x.IdProduct });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ItensVendaIdVenda_ItensVendaIdProduct",
                table: "Vendas",
                columns: new[] { "ItensVendaIdVenda", "ItensVendaIdProduct" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_VendasIdVenda_VendasIdProduct",
                table: "Products",
                columns: new[] { "VendasIdVenda", "VendasIdProduct" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ItensVendas_VendasIdVenda_VendasIdProduct",
                table: "Products",
                columns: new[] { "VendasIdVenda", "VendasIdProduct" },
                principalTable: "ItensVendas",
                principalColumns: new[] { "IdVenda", "IdProduct" });

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_ItensVendas_ItensVendaIdVenda_ItensVendaIdProduct",
                table: "Vendas",
                columns: new[] { "ItensVendaIdVenda", "ItensVendaIdProduct" },
                principalTable: "ItensVendas",
                principalColumns: new[] { "IdVenda", "IdProduct" });
        }
    }
}
