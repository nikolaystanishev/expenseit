using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace expensit.DataAccess.Migrations
{
    public partial class DbSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Name" },
                values: new object[] { "1", "profile1" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Name" },
                values: new object[] { "2", "profile2" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Name" },
                values: new object[] { "3", "profile3" });

            migrationBuilder.InsertData(
                table: "ExpenseRecords",
                columns: new[] { "Id", "Amount", "PayDate", "ProfileId", "Type" },
                values: new object[] { "1", 1000m, new DateTime(2021, 9, 17, 20, 29, 14, 249, DateTimeKind.Local).AddTicks(5364), "1", 0 });

            migrationBuilder.InsertData(
                table: "ExpenseRecords",
                columns: new[] { "Id", "Amount", "PayDate", "ProfileId", "Type" },
                values: new object[] { "2", 2000m, new DateTime(2021, 9, 18, 20, 29, 14, 254, DateTimeKind.Local).AddTicks(4901), "1", 0 });

            migrationBuilder.InsertData(
                table: "ExpenseRecords",
                columns: new[] { "Id", "Amount", "PayDate", "ProfileId", "Type" },
                values: new object[] { "3", 3000m, new DateTime(2021, 12, 26, 20, 29, 14, 254, DateTimeKind.Local).AddTicks(4983), "1", 0 });

            migrationBuilder.InsertData(
                table: "ExpenseRecords",
                columns: new[] { "Id", "Amount", "PayDate", "ProfileId", "Type" },
                values: new object[] { "4", 4000m, new DateTime(2021, 12, 26, 20, 29, 14, 254, DateTimeKind.Local).AddTicks(4995), "2", 0 });

            migrationBuilder.InsertData(
                table: "ExpenseRecords",
                columns: new[] { "Id", "Amount", "PayDate", "ProfileId", "Type" },
                values: new object[] { "5", 5000m, new DateTime(2021, 12, 26, 20, 29, 14, 254, DateTimeKind.Local).AddTicks(4999), "2", 0 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Color", "ExpenseRecordId", "Name" },
                values: new object[] { "1", "#123456", "2", "group1" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Color", "ExpenseRecordId", "Name" },
                values: new object[] { "2", "#123457", "2", "group2" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Color", "ExpenseRecordId", "Name" },
                values: new object[] { "3", "#123457", "3", "group2" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Color", "ExpenseRecordId", "Name" },
                values: new object[] { "4", "#123458", "3", "group3" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Color", "ExpenseRecordId", "Name" },
                values: new object[] { "5", "#123459", "5", "group4" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Color", "ExpenseRecordId", "Name" },
                values: new object[] { "6", "#123450", "5", "group5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenseRecords",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "ExpenseRecords",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "ExpenseRecords",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "ExpenseRecords",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "ExpenseRecords",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
