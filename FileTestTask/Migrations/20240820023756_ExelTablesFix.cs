using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileTestTask.Migrations
{
    /// <inheritdoc />
    public partial class ExelTablesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassEndRow",
                table: "AccountClasses");

            migrationBuilder.DropColumn(
                name: "ClassStartRow",
                table: "AccountClasses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClassEndRow",
                table: "AccountClasses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ClassStartRow",
                table: "AccountClasses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
