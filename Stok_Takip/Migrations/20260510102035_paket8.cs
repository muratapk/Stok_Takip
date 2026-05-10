using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stok_Takip.Migrations
{
    /// <inheritdoc />
    public partial class paket8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resimlers_Urunlers_UrunlerUrun_Id",
                table: "Resimlers");

            migrationBuilder.DropIndex(
                name: "IX_Resimlers_UrunlerUrun_Id",
                table: "Resimlers");

            migrationBuilder.DropColumn(
                name: "UrunlerUrun_Id",
                table: "Resimlers");

            migrationBuilder.AddColumn<string>(
                name: "Urun_Resim",
                table: "Urunlers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Resimlers_Urun_Id",
                table: "Resimlers",
                column: "Urun_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resimlers_Urunlers_Urun_Id",
                table: "Resimlers",
                column: "Urun_Id",
                principalTable: "Urunlers",
                principalColumn: "Urun_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resimlers_Urunlers_Urun_Id",
                table: "Resimlers");

            migrationBuilder.DropIndex(
                name: "IX_Resimlers_Urun_Id",
                table: "Resimlers");

            migrationBuilder.DropColumn(
                name: "Urun_Resim",
                table: "Urunlers");

            migrationBuilder.AddColumn<int>(
                name: "UrunlerUrun_Id",
                table: "Resimlers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resimlers_UrunlerUrun_Id",
                table: "Resimlers",
                column: "UrunlerUrun_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resimlers_Urunlers_UrunlerUrun_Id",
                table: "Resimlers",
                column: "UrunlerUrun_Id",
                principalTable: "Urunlers",
                principalColumn: "Urun_Id");
        }
    }
}
