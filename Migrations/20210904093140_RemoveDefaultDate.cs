using Microsoft.EntityFrameworkCore.Migrations;

namespace expensit.Migrations
{
    public partial class RemoveDefaultDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_ExpenseRecords_ExpenseRecordId",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_Group_ExpenseRecordId",
                table: "Groups",
                newName: "IX_Groups_ExpenseRecordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_ExpenseRecords_ExpenseRecordId",
                table: "Groups",
                column: "ExpenseRecordId",
                principalTable: "ExpenseRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_ExpenseRecords_ExpenseRecordId",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_ExpenseRecordId",
                table: "Group",
                newName: "IX_Group_ExpenseRecordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_ExpenseRecords_ExpenseRecordId",
                table: "Group",
                column: "ExpenseRecordId",
                principalTable: "ExpenseRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
