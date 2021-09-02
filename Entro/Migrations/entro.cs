using Microsoft.EntityFrameworkCore.Migrations;

namespace Entro.Migrations
{
    public partial class entro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migration genration 
            migrationBuilder.CreateTable(
                name: "Concepts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConceptName = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    TicketRate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concepts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    NumberOfPersons = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    ConceptId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
            table.PrimaryKey("PK_Tickets", x => x.Id);
            table.ForeignKey(
                name: "FK_Tickets_Concepts_ConceptId",
                column: x => x.ConceptId,
                principalTable: "Concepts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        });


            migrationBuilder.CreateTable(
                name: "Query",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    QueryDetail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Query", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Concepts");

            migrationBuilder.DropTable(
                name: "Query");
        }
    }
}
