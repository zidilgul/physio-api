using Microsoft.EntityFrameworkCore.Migrations;

namespace physio.Migrations
{
    public partial class lastClickedsTabloMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LastClickeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientsMoveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastClickeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LastClickeds_PatientsMoves_PatientsMoveId",
                        column: x => x.PatientsMoveId,
                        principalTable: "PatientsMoves",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LastClickeds_PatientsMoveId",
                table: "LastClickeds",
                column: "PatientsMoveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastClickeds");
        }
    }
}
