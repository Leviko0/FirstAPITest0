using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstAPITest.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Microcontrollers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClockFz = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Microcontrollers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Microcontrollers",
                columns: new[] { "Id", "ClockFz", "Manufacturer", "Model" },
                values: new object[,]
                {
                    { 1, 480, "Espressif", "ESP32S3" },
                    { 2, 240, "Espressif", "ESP32C3" },
                    { 3, 16, "Arduino", "UNO" },
                    { 4, 16, "Arduino", "Nano" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Microcontrollers");
        }
    }
}
