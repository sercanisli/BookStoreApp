using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 75m, "Karagöz ve Hacivat" },
                    { 2, 5m, "Hamlet" },
                    { 3, 100m, "Mesnevi" },
                    { 4, 15m, "Araba Sevdası" },
                    { 5, 55m, "Kaşağı" },
                    { 6, 150m, "Uçurtma Avcısı" },
                    { 7, 100m, "Ateşten Gömlek" },
                    { 8, 90m, "Çalukuşu" },
                    { 9, 45m, "Tutunamayanlar" },
                    { 10, 10000m, "Nutuk" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
