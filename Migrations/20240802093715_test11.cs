using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Register.Migrations
{
    /// <inheritdoc />
    public partial class test11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfilId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profils", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_ProfilId",
                table: "users",
                column: "ProfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Profils_ProfilId",
                table: "users",
                column: "ProfilId",
                principalTable: "Profils",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Profils_ProfilId",
                table: "users");

            migrationBuilder.DropTable(
                name: "Profils");

            migrationBuilder.DropIndex(
                name: "IX_users_ProfilId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ProfilId",
                table: "users");
        }
    }
}
