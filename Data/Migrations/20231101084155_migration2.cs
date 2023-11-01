using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseAuthentication_MicroAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "corporateid",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "corporaterole",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "department",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "saltpassword",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "corporateid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "corporaterole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "department",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "saltpassword",
                table: "Users");
        }
    }
}
