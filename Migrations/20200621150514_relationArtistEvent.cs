using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_kolos.Migrations
{
    public partial class relationArtistEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Artist_Event_IdEvent",
                table: "Artist_Event",
                column: "IdEvent");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Event_Artist_IdArtist",
                table: "Artist_Event",
                column: "IdArtist",
                principalTable: "Artist",
                principalColumn: "IdArtist",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Event_Event_IdEvent",
                table: "Artist_Event",
                column: "IdEvent",
                principalTable: "Event",
                principalColumn: "IdEvent",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Event_Artist_IdArtist",
                table: "Artist_Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Event_Event_IdEvent",
                table: "Artist_Event");

            migrationBuilder.DropIndex(
                name: "IX_Artist_Event_IdEvent",
                table: "Artist_Event");
        }
    }
}
