using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeCleverChallenge.Migrations
{
    /// <inheritdoc />
    public partial class FisrtMigrationWithAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InterestPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Interest = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AmountWithInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PureQuoteValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quote = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QuantityQuote = table.Column<int>(type: "int", nullable: true),
                    PaidQuotes = table.Column<int>(type: "int", nullable: true),
                    Iva = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpirationDay = table.Column<int>(type: "int", nullable: true),
                    DelayInterestPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalizedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditId = table.Column<int>(type: "int", nullable: false),
                    Quote = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PendingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayType = table.Column<int>(type: "int", nullable: false),
                    OperationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditPayment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.Sql(@"INSERT INTO[dbo].[User] ([UserName],[Name],[Password],[Active])VALUES('Admin', 'Admin', 'admin123', 1)");
            migrationBuilder.Sql(@"INSERT INTO[dbo].[PaymentType] ([Description],[Active])VALUES('Efectivo', 1)");
            migrationBuilder.Sql(@"INSERT INTO[dbo].[PaymentType] ([Description],[Active])VALUES('Credito', 1)");
            migrationBuilder.Sql(@"INSERT INTO[dbo].[PaymentType] ([Description],[Active])VALUES('Debito', 1)");
            migrationBuilder.Sql(@"INSERT INTO [dbo].[Client]([LastName],[Name],[Mail],[Address],[Active]) VALUES('Gomez', 'Pedro','pedrogomez@test.com','La casa de gomez', 1)");
            migrationBuilder.Sql(@"INSERT INTO [dbo].[Client]([LastName],[Name],[Mail],[Address],[Active]) VALUES('Perez', 'Juan','juanperez@test.com','La casa de perez', 1)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "CreditPayment");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
