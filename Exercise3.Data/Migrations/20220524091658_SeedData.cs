using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercise3.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "Id", "AgreementName", "AgreementType", "CreatedDate", "DaysUntilExpiration", "DistributorName", "EffectiveDate", "ExpirationDate", "QuoteNumber", "Status" },
                values: new object[] { 1, "Name 2", "Name 3", new DateTime(2022, 5, 24, 16, 16, 58, 638, DateTimeKind.Local).AddTicks(8900), "Name 5", "Name 4", new DateTime(2022, 5, 24, 16, 16, 58, 638, DateTimeKind.Local).AddTicks(8888), new DateTime(2022, 5, 24, 16, 16, 58, 638, DateTimeKind.Local).AddTicks(8900), "Name 1", 0 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "Id", "AgreementName", "AgreementType", "CreatedDate", "DaysUntilExpiration", "DistributorName", "EffectiveDate", "ExpirationDate", "QuoteNumber", "Status" },
                values: new object[] { 2, "Name 3", "Name 4", new DateTime(2022, 5, 24, 16, 16, 58, 638, DateTimeKind.Local).AddTicks(8904), "Name 6", "Name 5", new DateTime(2022, 5, 24, 16, 16, 58, 638, DateTimeKind.Local).AddTicks(8903), new DateTime(2022, 5, 24, 16, 16, 58, 638, DateTimeKind.Local).AddTicks(8903), "Name 2", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
