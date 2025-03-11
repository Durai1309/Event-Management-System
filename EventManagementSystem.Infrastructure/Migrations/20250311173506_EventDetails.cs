using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementSystem.Infrastructure.Migrations
{
    public partial class EventDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventDetailS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetailS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventDetailS_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EventDetailS",
                columns: new[] { "Id", "Description", "EventId", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, "Private Pool" },
                    { 2, null, 1, "Microwave" },
                    { 3, null, 1, "Private Balcony" },
                    { 4, null, 1, "1 king bed and 1 sofa bed" },
                    { 5, null, 2, "Private Plunge Pool" },
                    { 6, null, 2, "Microwave and Mini Refrigerator" },
                    { 7, null, 2, "Private Balcony" },
                    { 8, null, 2, "king bed or 2 double beds" },
                    { 9, null, 3, "Private Pool" },
                    { 10, null, 3, "Jacuzzi" },
                    { 11, null, 3, "Private Balcony" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDetailS_EventId",
                table: "EventDetailS",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventDetailS");
        }
    }
}
