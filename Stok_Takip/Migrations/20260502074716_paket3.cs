using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stok_Takip.Migrations
{
    /// <inheritdoc />
    public partial class paket3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resimlers",
                columns: table => new
                {
                    Resim_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resim_Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resim_Yolu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Urun_Id = table.Column<int>(type: "int", nullable: false),
                    UrunlerUrun_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resimlers", x => x.Resim_Id);
                    table.ForeignKey(
                        name: "FK_Resimlers_Urunlers_UrunlerUrun_Id",
                        column: x => x.UrunlerUrun_Id,
                        principalTable: "Urunlers",
                        principalColumn: "Urun_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resimlers_UrunlerUrun_Id",
                table: "Resimlers",
                column: "UrunlerUrun_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resimlers");
        }
    }
}
