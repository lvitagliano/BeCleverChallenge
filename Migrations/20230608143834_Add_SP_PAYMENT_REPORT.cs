using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeCleverChallenge.Migrations
{
    /// <inheritdoc />
    public partial class Add_SP_PAYMENT_REPORT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditReportModel",
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
                    AmountPay = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditReportModel", x => x.Id);
                });

            migrationBuilder.Sql(@"GO
                                    CREATE PROCEDURE SP_PAYMENT_REPORT
                                     @Desde datetime,
                                     @Hasta datetime
                                    AS
                                    BEGIN
	                                    SELECT cr.Id,cr.[Amount]
                                          ,cr.[InterestPercent]
                                          ,cr.[Interest]
                                          ,cr.[AmountWithInterest]
                                          ,cr.[PureQuoteValue]
                                          ,cr.[Quote]
                                          ,cr.[QuantityQuote]
                                          ,cr.[PaidQuotes]
                                          ,cr.[Iva]
                                          ,cr.[ExpirationDay]
                                          ,cr.[DelayInterestPercent]
                                          ,cr.[UserId]
                                          ,cr.[ClientId]
                                          ,cr.[CreatedAt]
                                          ,cr.[FinalizedDate],
	                                      sum(cp.Amount) as AmountPay 
                                    FROM [dbo].[Credit] cr join [dbo].[CreditPayment] cp on cp.CreditId = cr.Id
                                    where CreatedAt between @Desde and @Hasta
                                    group by cr.Id
	                                      ,cr.[Amount]
                                          ,cr.[InterestPercent]
                                          ,cr.[Interest]
                                          ,cr.[AmountWithInterest]
                                          ,cr.[PureQuoteValue]
                                          ,cr.[Quote]
                                          ,cr.[QuantityQuote]
                                          ,cr.[PaidQuotes]
                                          ,cr.[Iva]
                                          ,cr.[ExpirationDay]
                                          ,cr.[DelayInterestPercent]
                                          ,cr.[UserId]
                                          ,cr.[ClientId]
                                          ,cr.[CreatedAt]
                                          ,cr.[FinalizedDate]
        END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditReportModel");
            migrationBuilder.Sql(@"DROP PROCEDURE[dbo].[SP_PAYMENT_REPORT]");
        }
    }
}
