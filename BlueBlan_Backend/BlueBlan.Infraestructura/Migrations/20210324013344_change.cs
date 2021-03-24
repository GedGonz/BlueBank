using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueBlan.Infraestructura.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Accounts",
                type: "DECIMAL(9,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(5,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Accounts",
                type: "DECIMAL(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(9,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Accounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
