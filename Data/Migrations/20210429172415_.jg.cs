using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Data.Migrations
{
    public partial class jg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "SalesDetail",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "SalesDetail",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
