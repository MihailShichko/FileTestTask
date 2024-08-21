using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileTestTask.Migrations
{
    /// <inheritdoc />
    public partial class ExelTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassIndex = table.Column<int>(type: "int", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassStartRow = table.Column<long>(type: "bigint", nullable: false),
                    ClassEndRow = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    OpeningBalanceActive = table.Column<double>(type: "float", nullable: false),
                    OpeningBalancePassive = table.Column<double>(type: "float", nullable: false),
                    DebitTurnover = table.Column<double>(type: "float", nullable: false),
                    CreditTurnover = table.Column<double>(type: "float", nullable: false),
                    ClosingBalanceActive = table.Column<double>(type: "float", nullable: false),
                    ClosingBalancePassive = table.Column<double>(type: "float", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "AccountClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClassId",
                table: "Accounts",
                column: "ClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountClasses");
        }
    }
}
