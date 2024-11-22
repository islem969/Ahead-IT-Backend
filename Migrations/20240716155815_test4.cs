using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Register.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QualificationId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "qualification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qualification", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_QualificationId",
                table: "users",
                column: "QualificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_qualification_QualificationId",
                table: "users",
                column: "QualificationId",
                principalTable: "qualification",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_qualification_QualificationId",
                table: "users");

            migrationBuilder.DropTable(
                name: "qualification");

            migrationBuilder.DropIndex(
                name: "IX_users_QualificationId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "QualificationId",
                table: "users");
        }
    }
}
