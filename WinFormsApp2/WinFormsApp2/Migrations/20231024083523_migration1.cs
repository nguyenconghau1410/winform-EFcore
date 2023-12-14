using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WinFormsApp2.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    DiseaseID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.DiseaseID);
                });

            migrationBuilder.CreateTable(
                name: "Symptons",
                columns: table => new
                {
                    SymptonID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiseaseID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptons", x => x.SymptonID);
                    table.ForeignKey(
                        name: "FK_Symptons_Diseases_DiseaseID",
                        column: x => x.DiseaseID,
                        principalTable: "Diseases",
                        principalColumn: "DiseaseID");
                });

            migrationBuilder.InsertData(
                table: "Diseases",
                columns: new[] { "DiseaseID", "Name" },
                values: new object[,]
                {
                    { "Colds", "Bệnh cảm" },
                    { "Diabetes", "Bệnh tiểu đường" },
                    { "DigestiveDiseases", "Bệnh tiêu hóa" },
                    { "HeartDisease", "Bệnh cơ tim" },
                    { "IntestinalDisease", "Bệnh đường ruột" },
                    { "KidneyDisease", "Bệnh thận" },
                    { "LiverDisease", "Bệnh gan" },
                    { "LungDisease", "Bệnh phổi" },
                    { "Nephrolithiasis", "Bệnh sỏi thận" },
                    { "Stomachache", "Bệnh đau dạ dày" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Symptons_DiseaseID",
                table: "Symptons",
                column: "DiseaseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Symptons");

            migrationBuilder.DropTable(
                name: "Diseases");
        }
    }
}
