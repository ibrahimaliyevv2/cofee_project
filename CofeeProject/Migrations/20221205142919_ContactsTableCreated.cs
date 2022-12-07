using Microsoft.EntityFrameworkCore.Migrations;

namespace CofeeProject.Migrations
{
    public partial class ContactsTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationAdress = table.Column<string>(maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 100, nullable: true),
                    EmailAdress = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
