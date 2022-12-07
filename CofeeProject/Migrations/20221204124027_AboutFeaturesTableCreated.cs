using Microsoft.EntityFrameworkCore.Migrations;

namespace CofeeProject.Migrations
{
    public partial class AboutFeaturesTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title1 = table.Column<string>(maxLength: 25, nullable: false),
                    Title2 = table.Column<string>(maxLength: 25, nullable: false),
                    Title3 = table.Column<string>(maxLength: 25, nullable: false),
                    Description1 = table.Column<string>(nullable: true),
                    Description2 = table.Column<string>(nullable: true),
                    Description3 = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutFeatures", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutFeatures");
        }
    }
}
