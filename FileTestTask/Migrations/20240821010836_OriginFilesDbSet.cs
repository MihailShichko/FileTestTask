using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileTestTask.Migrations
{
    /// <inheritdoc />
    public partial class OriginFilesDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountClasses_OriginFile_OriginFileId",
                table: "AccountClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OriginFile",
                table: "OriginFile");

            migrationBuilder.RenameTable(
                name: "OriginFile",
                newName: "OriginFiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OriginFiles",
                table: "OriginFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountClasses_OriginFiles_OriginFileId",
                table: "AccountClasses",
                column: "OriginFileId",
                principalTable: "OriginFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountClasses_OriginFiles_OriginFileId",
                table: "AccountClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OriginFiles",
                table: "OriginFiles");

            migrationBuilder.RenameTable(
                name: "OriginFiles",
                newName: "OriginFile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OriginFile",
                table: "OriginFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountClasses_OriginFile_OriginFileId",
                table: "AccountClasses",
                column: "OriginFileId",
                principalTable: "OriginFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
