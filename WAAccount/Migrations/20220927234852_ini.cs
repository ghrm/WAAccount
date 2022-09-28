using Microsoft.EntityFrameworkCore.Migrations;

namespace WAAccount.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Account = table.Column<string>(type: "nchar(10)", nullable: false),
                    AcctType = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Deparment = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypicalBal = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DebitOffset = table.Column<string>(type: "nchar(10)", nullable: true),
                    CreditOffset = table.Column<string>(type: "nchar(10)", nullable: true),
                    Sts = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Account);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
