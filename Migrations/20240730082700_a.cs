using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Register.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Civil_StatusId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Civil_Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Civil_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_Civil_StatusId",
                table: "users",
                column: "Civil_StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Civil_Status_Civil_StatusId",
                table: "users",
                column: "Civil_StatusId",
                principalTable: "Civil_Status",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Civil_Status_Civil_StatusId",
                table: "users");

            migrationBuilder.DropTable(
                name: "Civil_Status");

            migrationBuilder.DropIndex(
                name: "IX_users_Civil_StatusId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Civil_StatusId",
                table: "users");
        }
    }
}
