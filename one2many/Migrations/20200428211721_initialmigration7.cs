using Microsoft.EntityFrameworkCore.Migrations;

namespace one2many.Migrations
{
    public partial class initialmigration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classinfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classinfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    term = table.Column<string>(nullable: false),
                    termresult = table.Column<int>(nullable: false),
                    meritpostion = table.Column<int>(nullable: false),
                    Studentid = table.Column<int>(nullable: false),
                    Classinfoid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.id);
                    table.ForeignKey(
                        name: "FK_Result_Classinfo_Classinfoid",
                        column: x => x.Classinfoid,
                        principalTable: "Classinfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Result_Student_Studentid",
                        column: x => x.Studentid,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studentaction",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resultsid = table.Column<int>(nullable: true),
                    Classinfosid = table.Column<int>(nullable: true),
                    Studentsid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studentaction", x => x.id);
                    table.ForeignKey(
                        name: "FK_Studentaction_Classinfo_Classinfosid",
                        column: x => x.Classinfosid,
                        principalTable: "Classinfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Studentaction_Result_Resultsid",
                        column: x => x.Resultsid,
                        principalTable: "Result",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Studentaction_Student_Studentsid",
                        column: x => x.Studentsid,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Result_Classinfoid",
                table: "Result",
                column: "Classinfoid");

            migrationBuilder.CreateIndex(
                name: "IX_Result_Studentid",
                table: "Result",
                column: "Studentid");

            migrationBuilder.CreateIndex(
                name: "IX_Studentaction_Classinfosid",
                table: "Studentaction",
                column: "Classinfosid");

            migrationBuilder.CreateIndex(
                name: "IX_Studentaction_Resultsid",
                table: "Studentaction",
                column: "Resultsid");

            migrationBuilder.CreateIndex(
                name: "IX_Studentaction_Studentsid",
                table: "Studentaction",
                column: "Studentsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studentaction");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Classinfo");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
