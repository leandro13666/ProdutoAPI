using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdutoAPI.Migrations
{
    public partial class VinculoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrudutoId",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_PrudutoId",
                table: "Produto",
                column: "PrudutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Produto_PrudutoId",
                table: "Produto",
                column: "PrudutoId",
                principalTable: "Produto",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Produto_PrudutoId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_PrudutoId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "PrudutoId",
                table: "Produto");
        }
    }
}
