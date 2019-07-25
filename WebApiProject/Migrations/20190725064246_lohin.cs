using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class lohin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLoginInfo",
                columns: table => new
                {
                    SerialNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginInfo", x => x.SerialNo);
                });

            migrationBuilder.InsertData(
                table: "UserLoginInfo",
                columns: new[] { "SerialNo", "Email", "Password" },
                values: new object[] { 1, "sanaaroojbutt@hotmail.com", "111111" });

            migrationBuilder.InsertData(
                table: "UserLoginInfo",
                columns: new[] { "SerialNo", "Email", "Password" },
                values: new object[] { 2, "sahar@hotmail.com", "222222" });

            migrationBuilder.InsertData(
                table: "UserLoginInfo",
                columns: new[] { "SerialNo", "Email", "Password" },
                values: new object[] { 3, "alina@hotmail.com", "333333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLoginInfo");
        }
    }
}
