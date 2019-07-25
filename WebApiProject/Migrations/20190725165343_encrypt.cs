using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class encrypt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserLoginInfo",
                keyColumn: "SerialNo",
                keyValue: 1,
                column: "Password",
                value: "9FE4UYePyEkwIsNUsSjtgGIFJt7KXuCRdSqwg0hlRNo=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserLoginInfo",
                keyColumn: "SerialNo",
                keyValue: 1,
                column: "Password",
                value: "111111");
        }
    }
}
