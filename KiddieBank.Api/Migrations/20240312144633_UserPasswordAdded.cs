using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KiddieBank.Api.Migrations
{
    /// <inheritdoc />
    public partial class UserPasswordAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "VARBINARY(MAX)",
                nullable: true);
           
            migrationBuilder.AddColumn<byte[]>(
               name: "PasswordSalt",
               table: "Users",
               type: "VARBINARY(MAX)",
               nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
           name: "PasswordHash",
           table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");
        }
    }
}
