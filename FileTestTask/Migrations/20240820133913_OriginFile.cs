using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileTestTask.Migrations
{
    /// <inheritdoc />
    public partial class OriginFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OriginFileId",
                table: "AccountClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OriginFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OriginFile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountClasses_OriginFileId",
                table: "AccountClasses",
                column: "OriginFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountClasses_OriginFile_OriginFileId",
                table: "AccountClasses",
                column: "OriginFileId",
                principalTable: "OriginFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountClasses_OriginFile_OriginFileId",
                table: "AccountClasses");

            migrationBuilder.DropTable(
                name: "OriginFile");

            migrationBuilder.DropIndex(
                name: "IX_AccountClasses_OriginFileId",
                table: "AccountClasses");

            migrationBuilder.DropColumn(
                name: "OriginFileId",
                table: "AccountClasses");
        }
    }
}
