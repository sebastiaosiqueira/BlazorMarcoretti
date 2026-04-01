using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class IncluiContatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contatos",
                columns: new[] { "Id", "Email", "Nome" },
                values: new object[,]
                {
                    { 1, "sebastiaosiqueira@gmail.com", "Sebastiao siqueira" },
                    { 2, "ruth@gmail", "Ruth Regina" },
                    { 3, "kayon@gmail", "Kayon Guilherme" },
                    { 4, "ruth@gmail", "Emau" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contatos");
        }
    }
}
