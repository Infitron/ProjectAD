using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Database.Migrations
{
    public partial class inituserloginpasswordremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                schema: "dbAd",
                table: "UserLogin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "dbAd",
                table: "UserLogin",
                unicode: false,
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
