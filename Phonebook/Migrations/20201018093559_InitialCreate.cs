using Microsoft.EntityFrameworkCore.Migrations;

namespace Phonebook.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneBook",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneBook", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhoneBookEntry",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhonebookID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneBookEntry", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneBook");

            migrationBuilder.DropTable(
                name: "PhoneBookEntry");
        }
    }
}
