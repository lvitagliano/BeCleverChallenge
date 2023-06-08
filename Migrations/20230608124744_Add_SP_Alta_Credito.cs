using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeCleverChallenge.Migrations
{
    /// <inheritdoc />
    public partial class Add_SP_Alta_Credito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" GO
                            CREATE OR ALTER PROCEDURE [dbo].[SP_ALTA_CREDITO]
                                @Amount decimal(18, 2),
                                @InterestPercent decimal(18, 2),
                                @QuantityQuote int,
                                @Iva decimal(18, 2) = 0,
                                @ExpirationDay int,
                                @DelayInterestPercent decimal(18, 2),
                                @UserId int,
                                @ClientId int
                            AS
                            BEGIN
                            DECLARE @calcInterest decimal(18, 2);
                                        DECLARE @calcAmountWithInterest decimal(18, 2);
                                        DECLARE @calcAmountIva decimal(18, 2);
                                        BEGIN
                                            SET @calcInterest = @Amount * @InterestPercent / 100;
                                        SET @calcAmountIva = @Amount * @Iva / 100;
                                        SET @calcAmountWithInterest = @Amount + @calcInterest + @calcAmountIva;
                                        END
                                        INSERT INTO[dbo].[Credit]
                                                   ([Amount]
                                       ,[InterestPercent]
                                       ,[Interest]
                                       ,[PureQuoteValue]
                                       ,[Quote]
                                       ,[QuantityQuote]
                                       ,[Iva]
                                       ,[ExpirationDay]
                                       ,[DelayInterestPercent]
                                       ,[UserId]
                                       ,[ClientId]
                                       ,[Active]
                                       ,[AmountWithInterest]
									   ,[PaidQuotes]
									   ,[CreatedAt])
                                 VALUES
                                       (@Amount
                                       , @InterestPercent
                                       , @calcInterest
                                       , @Amount / @QuantityQuote
                                       , @calcAmountWithInterest / @QuantityQuote
                                       , @QuantityQuote
                                       , @Iva
                                       , @ExpirationDay
                                       , @DelayInterestPercent
                                       , @UserId
                                       , @ClientId
                                       , 1
                                       , @calcAmountWithInterest
									   ,0
									   ,GETDATE())
                                END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE[dbo].[SP_ALTA_CREDITO]");
        }
    }
}
