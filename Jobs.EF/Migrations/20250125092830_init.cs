using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jobs.EF.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requirement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PositionApplications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicantEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DbFilename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionApplications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PositionApplications_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "ID", "Company", "Description", "IsDeleted", "Location", "Requirement", "Salary", "Title" },
                values: new object[,]
                {
                    { 1, "Coptic Orphans", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Beatae accusamus voluptatem error natus earum animi dolores, iure qui repellendus repellat perferendis, molestiae cumque dolore pariatur praesentium illo. Nihil, nostrum odit!", false, "Sheraton", "2-4 years of related professional experience", 40000f, "MD Full-Stack Developer" },
                    { 2, "Coptic Orphans", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Beatae accusamus voluptatem error natus earum animi dolores, iure qui repellendus repellat perferendis, molestiae cumque dolore pariatur praesentium illo. Nihil, nostrum odit!", false, "Sheraton", "4-8 years of related professional experience", 60000f, "SR Full-Stack Developer" },
                    { 3, "Company name", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Beatae accusamus voluptatem error natus earum animi dolores, iure qui repellendus repellat perferendis, molestiae cumque dolore pariatur praesentium illo. Nihil, nostrum odit!", false, "test Location", "0-2 years of related professional experience", 30000f, "JR .net Developer" },
                    { 4, "Company name", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Beatae accusamus voluptatem error natus earum animi dolores, iure qui repellendus repellat perferendis, molestiae cumque dolore pariatur praesentium illo. Nihil, nostrum odit!", false, "test Location", "4-8 years of related professional experience", 55000f, "SR .net Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PositionApplications_PositionID",
                table: "PositionApplications",
                column: "PositionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionApplications");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
