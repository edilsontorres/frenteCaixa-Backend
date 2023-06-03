using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoCaixa.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionamentoNtoN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVendas_Vendas_VendaId",
                table: "ItemVendas");

            migrationBuilder.DropIndex(
                name: "IX_ItemVendas_ProductId",
                table: "ItemVendas");

            migrationBuilder.AlterColumn<int>(
                name: "VendaId",
                table: "ItemVendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendas_ProductId",
                table: "ItemVendas",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVendas_Vendas_VendaId",
                table: "ItemVendas",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVendas_Vendas_VendaId",
                table: "ItemVendas");

            migrationBuilder.DropIndex(
                name: "IX_ItemVendas_ProductId",
                table: "ItemVendas");

            migrationBuilder.AlterColumn<int>(
                name: "VendaId",
                table: "ItemVendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendas_ProductId",
                table: "ItemVendas",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVendas_Vendas_VendaId",
                table: "ItemVendas",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id");
        }
    }
}
