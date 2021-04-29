using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Data.Migrations
{
    public partial class sd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "SalesDetail",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Sales",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "BillNo",
                table: "Sales",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "SalesDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<long>(
                name: "Remarks",
                table: "Sales",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BillNo",
                table: "Sales",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
