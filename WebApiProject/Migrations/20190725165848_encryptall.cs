using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class encryptall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserLoginInfo",
                keyColumn: "SerialNo",
                keyValue: 1,
                column: "Password",
                value: "7nMpYVDoXMIAOnrp9dyuuRVdC7mRE9tHf/394KBwUkQ=");

            migrationBuilder.UpdateData(
                table: "UserLoginInfo",
                keyColumn: "SerialNo",
                keyValue: 2,
                column: "Password",
                value: "0AE08S4IHdYwEUvl881oq4+7KAG66/OImhsUDrmJrP0=");

            migrationBuilder.UpdateData(
                table: "UserLoginInfo",
                keyColumn: "SerialNo",
                keyValue: 3,
                column: "Password",
                value: "2knL4xW6bRbZXOTfMjjtFIAdt3Cp4AV0ShoWZO1kzcE=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserLoginInfo",
                keyColumn: "SerialNo",
                keyValue: 1,
                column: "Password",
                value: "9FE4UYePyEkwIsNUsSjtgGIFJt7KXuCRdSqwg0hlRNo=");

            migrationBuilder.UpdateData(
                table: "UserLoginInfo",
                keyColumn: "SerialNo",
                keyValue: 2,
                column: "Password",
                value: "222222");

            migrationBuilder.UpdateData(
                table: "UserLoginInfo",
                keyColumn: "SerialNo",
                keyValue: 3,
                column: "Password",
                value: "333333");
        }
    }
}
