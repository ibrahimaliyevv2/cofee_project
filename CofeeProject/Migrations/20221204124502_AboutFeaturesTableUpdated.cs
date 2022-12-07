using Microsoft.EntityFrameworkCore.Migrations;

namespace CofeeProject.Migrations
{
    public partial class AboutFeaturesTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddedText1",
                table: "AboutFeatures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedText2",
                table: "AboutFeatures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedText3",
                table: "AboutFeatures",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedText1",
                table: "AboutFeatures");

            migrationBuilder.DropColumn(
                name: "AddedText2",
                table: "AboutFeatures");

            migrationBuilder.DropColumn(
                name: "AddedText3",
                table: "AboutFeatures");
        }
    }
}
