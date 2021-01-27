using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AplikasiPerpustakaan.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id_Author = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    penulis = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    umur = table.Column<int>(type: "INTEGER", nullable: false),
                    asal = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    pena = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    hobi = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id_Author);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id_Publisher = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    penerbit = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    alamat = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    pemimpin = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id_Publisher);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id_Book = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    genre = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    jumlah = table.Column<int>(type: "INTEGER", nullable: false),
                    judul = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Id_Author = table.Column<int>(type: "INTEGER", nullable: true),
                    Id_Publisher = table.Column<int>(type: "INTEGER", nullable: true),
                    AuthorId_Author = table.Column<int>(type: "INTEGER", nullable: true),
                    PublisherId_Publisher = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id_Book);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId_Author",
                        column: x => x.AuthorId_Author,
                        principalTable: "Author",
                        principalColumn: "Id_Author",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherId_Publisher",
                        column: x => x.PublisherId_Publisher,
                        principalTable: "Publisher",
                        principalColumn: "Id_Publisher",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Borrow",
                columns: table => new
                {
                    Id_Borrow = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nama_peminjam = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    tanggal_pinjam = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Id_Book = table.Column<int>(type: "INTEGER", nullable: true),
                    lama_pinjam = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId_Book = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrow", x => x.Id_Borrow);
                    table.ForeignKey(
                        name: "FK_Borrow_Book_BookId_Book",
                        column: x => x.BookId_Book,
                        principalTable: "Book",
                        principalColumn: "Id_Book",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Return",
                columns: table => new
                {
                    Id_Return = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nama_pengembali = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    tanggal_pengembalian = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Id_Borrow = table.Column<int>(type: "INTEGER", nullable: true),
                    ket = table.Column<string>(type: "TEXT", nullable: true),
                    BorrowId_Borrow = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Return", x => x.Id_Return);
                    table.ForeignKey(
                        name: "FK_Return_Borrow_BorrowId_Borrow",
                        column: x => x.BorrowId_Borrow,
                        principalTable: "Borrow",
                        principalColumn: "Id_Borrow",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId_Author",
                table: "Book",
                column: "AuthorId_Author");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId_Publisher",
                table: "Book",
                column: "PublisherId_Publisher");

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_BookId_Book",
                table: "Borrow",
                column: "BookId_Book");

            migrationBuilder.CreateIndex(
                name: "IX_Return_BorrowId_Borrow",
                table: "Return",
                column: "BorrowId_Borrow");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Return");

            migrationBuilder.DropTable(
                name: "Borrow");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
