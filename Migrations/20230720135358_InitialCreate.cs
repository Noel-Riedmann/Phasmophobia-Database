using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhasmophobiaDatabase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
     name: "Ghosts",
     columns: table => new
     {
         GhostId = table.Column<int>(type: "int", nullable: false)
             .Annotation("SqlServer:Identity", "1, 1"),
         Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
         JournalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
         Strengths = table.Column<string>(type: "nvarchar(max)", nullable: false),
         Weaknesses = table.Column<string>(type: "nvarchar(max)", nullable: false),
         Behaviour = table.Column<string>(type: "nvarchar(max)", nullable: false),
         Test = table.Column<string>(type: "nvarchar(max)", nullable: false)
     },
     constraints: table =>
     {
         table.PrimaryKey("PK_Ghosts", x => x.GhostId);
     });


            migrationBuilder.CreateTable(
                name: "Evidence",
                columns: table => new
                {
                    EvidenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidence", x => x.EvidenceId);
                    table.ForeignKey(
                        name: "FK_Evidence_Ghosts_GhostId",
                        column: x => x.GhostId,
                        principalTable: "Ghosts",
                        principalColumn: "GhostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanityThreshold",
                columns: table => new
                {
                    SanityThresholdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanityThreshold", x => x.SanityThresholdId);
                    table.ForeignKey(
                        name: "FK_SanityThreshold_Ghosts_GhostId",
                        column: x => x.GhostId,
                        principalTable: "Ghosts",
                        principalColumn: "GhostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speed",
                columns: table => new
                {
                    SpeedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speed", x => x.SpeedId);
                    table.ForeignKey(
                        name: "FK_Speed_Ghosts_GhostId",
                        column: x => x.GhostId,
                        principalTable: "Ghosts",
                        principalColumn: "GhostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evidence_GhostId",
                table: "Evidence",
                column: "GhostId");

            migrationBuilder.CreateIndex(
                name: "IX_SanityThreshold_GhostId",
                table: "SanityThreshold",
                column: "GhostId");

            migrationBuilder.CreateIndex(
                name: "IX_Speed_GhostId",
                table: "Speed",
                column: "GhostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evidence");

            migrationBuilder.DropTable(
                name: "SanityThreshold");

            migrationBuilder.DropTable(
                name: "Speed");

            migrationBuilder.DropTable(
                name: "Ghosts");
        }
    }
}
