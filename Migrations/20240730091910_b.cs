using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Register.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Civil_StatusId",
                table: "carrieres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_carrieres_Civil_StatusId",
                table: "carrieres",
                column: "Civil_StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_carrieres_Civil_Status_Civil_StatusId",
                table: "carrieres",
                column: "Civil_StatusId",
                principalTable: "Civil_Status",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carrieres_Civil_Status_Civil_StatusId",
                table: "carrieres");

            migrationBuilder.DropIndex(
                name: "IX_carrieres_Civil_StatusId",
                table: "carrieres");

            migrationBuilder.DropColumn(
                name: "Civil_StatusId",
                table: "carrieres");
        }
    }
}
