using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stok_Takip.Migrations
{
    /// <inheritdoc />
    public partial class paket45 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    YorumlarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YorumYapan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Urun_Id = table.Column<int>(type: "int", nullable: false),
                    UrunlerUrun_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.YorumlarId);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Urunlers_UrunlerUrun_Id",
                        column: x => x.UrunlerUrun_Id,
                        principalTable: "Urunlers",
                        principalColumn: "Urun_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_UrunlerUrun_Id",
                table: "Yorumlar",
                column: "UrunlerUrun_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Yorumlar");
        }
    }
}
