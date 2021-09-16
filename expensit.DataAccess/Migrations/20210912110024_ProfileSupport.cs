using Microsoft.EntityFrameworkCore.Migrations;

namespace expensit.DataAccess.Migrations
{
    public partial class ProfileSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileId",
                table: "ExpenseRecords",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseRecords_ProfileId",
                table: "ExpenseRecords",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseRecords_Profiles_ProfileId",
                table: "ExpenseRecords",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseRecords_Profiles_ProfileId",
                table: "ExpenseRecords");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseRecords_ProfileId",
                table: "ExpenseRecords");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "ExpenseRecords");
        }
    }
}
