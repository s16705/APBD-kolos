using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_kolos.Migrations
{
    public partial class addOrganiserandRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organiser",
                columns: table => new
                {
                    IdOrganiser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organiser", x => x.IdOrganiser);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_Organiser_IdOrganiser",
                table: "Event_Organiser",
                column: "IdOrganiser");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Organiser_Event_IdEvent",
                table: "Event_Organiser",
                column: "IdEvent",
                principalTable: "Event",
                principalColumn: "IdEvent",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Organiser_Organiser_IdOrganiser",
                table: "Event_Organiser",
                column: "IdOrganiser",
                principalTable: "Organiser",
                principalColumn: "IdOrganiser",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Organiser_Event_IdEvent",
                table: "Event_Organiser");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Organiser_Organiser_IdOrganiser",
                table: "Event_Organiser");

            migrationBuilder.DropTable(
                name: "Organiser");

            migrationBuilder.DropIndex(
                name: "IX_Event_Organiser_IdOrganiser",
                table: "Event_Organiser");
        }
    }
}
