using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercise3.Data.Migrations
{
    public partial class intital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuoteNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgreementName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgreementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistributorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysUntilExpiration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "Id", "AgreementName", "AgreementType", "CreatedDate", "DaysUntilExpiration", "DistributorName", "EffectiveDate", "ExpirationDate", "QuoteNumber", "Status" },
                values: new object[] { 1, "Name 2", "Name 3", new DateTime(2022, 5, 25, 10, 26, 13, 730, DateTimeKind.Local).AddTicks(8433), 1, "Name 4", new DateTime(2022, 5, 25, 10, 26, 13, 730, DateTimeKind.Local).AddTicks(8425), new DateTime(2022, 5, 25, 10, 26, 13, 730, DateTimeKind.Local).AddTicks(8432), "Name 1", "Invalid" });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "Id", "AgreementName", "AgreementType", "CreatedDate", "DaysUntilExpiration", "DistributorName", "EffectiveDate", "ExpirationDate", "QuoteNumber", "Status" },
                values: new object[] { 2, "Name 3", "Name 4", new DateTime(2022, 5, 25, 10, 26, 13, 730, DateTimeKind.Local).AddTicks(8437), 2, "Name 5", new DateTime(2022, 5, 25, 10, 26, 13, 730, DateTimeKind.Local).AddTicks(8435), new DateTime(2022, 5, 25, 10, 26, 13, 730, DateTimeKind.Local).AddTicks(8436), "Name 2", "Published" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements");
        }
    }
}
