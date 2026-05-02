using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stok_Takip.Migrations
{
    /// <inheritdoc />
    public partial class paket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorilers",
                columns: table => new
                {
                    Kategori_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori_Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorilers", x => x.Kategori_Id);
                });

            migrationBuilder.CreateTable(
                name: "Musterilers",
                columns: table => new
                {
                    Musteri_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Musteri_Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musterilers", x => x.Musteri_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tedarikcis",
                columns: table => new
                {
                    Tedarikci_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firma_Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yetkili_Kisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tedarikcis", x => x.Tedarikci_Id);
                });

            migrationBuilder.CreateTable(
                name: "Urunlers",
                columns: table => new
                {
                    Urun_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Urun_Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kategori_Id = table.Column<int>(type: "int", nullable: true),
                    Barkod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alis_Fiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Satis_Fiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Stok_Miktari = table.Column<int>(type: "int", nullable: true),
                    Minumum_Miktari = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunlers", x => x.Urun_Id);
                    table.ForeignKey(
                        name: "FK_Urunlers_Kategorilers_Kategori_Id",
                        column: x => x.Kategori_Id,
                        principalTable: "Kategorilers",
                        principalColumn: "Kategori_Id");
                });

            migrationBuilder.CreateTable(
                name: "SatisSatislar",
                columns: table => new
                {
                    Satislar_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Musteri_Id = table.Column<int>(type: "int", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Toplam_Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisSatislar", x => x.Satislar_Id);
                    table.ForeignKey(
                        name: "FK_SatisSatislar_Musterilers_Musteri_Id",
                        column: x => x.Musteri_Id,
                        principalTable: "Musterilers",
                        principalColumn: "Musteri_Id");
                });

            migrationBuilder.CreateTable(
                name: "Alis",
                columns: table => new
                {
                    Alis_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tedarikci_Id = table.Column<int>(type: "int", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Toplam_Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alis", x => x.Alis_Id);
                    table.ForeignKey(
                        name: "FK_Alis_Tedarikcis_Tedarikci_Id",
                        column: x => x.Tedarikci_Id,
                        principalTable: "Tedarikcis",
                        principalColumn: "Tedarikci_Id");
                });

            migrationBuilder.CreateTable(
                name: "StokHareketleris",
                columns: table => new
                {
                    Hareket_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Urun_Id = table.Column<int>(type: "int", nullable: true),
                    Hareket_Turu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miktari = table.Column<int>(type: "int", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokHareketleris", x => x.Hareket_Id);
                    table.ForeignKey(
                        name: "FK_StokHareketleris_Urunlers_Urun_Id",
                        column: x => x.Urun_Id,
                        principalTable: "Urunlers",
                        principalColumn: "Urun_Id");
                });

            migrationBuilder.CreateTable(
                name: "SatisDetay",
                columns: table => new
                {
                    SatisDetay_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Satis_Id = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    Miktari = table.Column<int>(type: "int", nullable: true),
                    Birim_Fiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Urun_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisDetay", x => x.SatisDetay_Id);
                    table.ForeignKey(
                        name: "FK_SatisDetay_SatisSatislar_Satis_Id",
                        column: x => x.Satis_Id,
                        principalTable: "SatisSatislar",
                        principalColumn: "Satislar_Id");
                    table.ForeignKey(
                        name: "FK_SatisDetay_Urunlers_Urun_Id",
                        column: x => x.Urun_Id,
                        principalTable: "Urunlers",
                        principalColumn: "Urun_Id");
                });

            migrationBuilder.CreateTable(
                name: "AlisDetay",
                columns: table => new
                {
                    AlisDetay_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alis_Id = table.Column<int>(type: "int", nullable: true),
                    Urun_Id = table.Column<int>(type: "int", nullable: true),
                    Miktari = table.Column<int>(type: "int", nullable: true),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlisDetay", x => x.AlisDetay_Id);
                    table.ForeignKey(
                        name: "FK_AlisDetay_Alis_Alis_Id",
                        column: x => x.Alis_Id,
                        principalTable: "Alis",
                        principalColumn: "Alis_Id");
                    table.ForeignKey(
                        name: "FK_AlisDetay_Urunlers_Urun_Id",
                        column: x => x.Urun_Id,
                        principalTable: "Urunlers",
                        principalColumn: "Urun_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alis_Tedarikci_Id",
                table: "Alis",
                column: "Tedarikci_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AlisDetay_Alis_Id",
                table: "AlisDetay",
                column: "Alis_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AlisDetay_Urun_Id",
                table: "AlisDetay",
                column: "Urun_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SatisDetay_Satis_Id",
                table: "SatisDetay",
                column: "Satis_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SatisDetay_Urun_Id",
                table: "SatisDetay",
                column: "Urun_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SatisSatislar_Musteri_Id",
                table: "SatisSatislar",
                column: "Musteri_Id");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketleris_Urun_Id",
                table: "StokHareketleris",
                column: "Urun_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Urunlers_Kategori_Id",
                table: "Urunlers",
                column: "Kategori_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlisDetay");

            migrationBuilder.DropTable(
                name: "SatisDetay");

            migrationBuilder.DropTable(
                name: "StokHareketleris");

            migrationBuilder.DropTable(
                name: "Alis");

            migrationBuilder.DropTable(
                name: "SatisSatislar");

            migrationBuilder.DropTable(
                name: "Urunlers");

            migrationBuilder.DropTable(
                name: "Tedarikcis");

            migrationBuilder.DropTable(
                name: "Musterilers");

            migrationBuilder.DropTable(
                name: "Kategorilers");
        }
    }
}
