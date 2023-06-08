using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeCleverChallenge.Migrations
{
    /// <inheritdoc />
    public partial class Add_SP_Alta_Pago_AND_SP_Afecta_Pago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"GO
                                CREATE PROCEDURE SP_AFECTAR_CUOTA 
	                                @Quote int,
	                                @CreditId int
                                AS
                                BEGIN
	                                UPDATE [dbo].[Credit] SET [PaidQuotes] = @Quote WHERE Id = @CreditId
                                END");
            migrationBuilder.Sql(@"GO
                                CREATE OR ALTER PROCEDURE SP_ALTA_PAGO 
	                                @CreditId int,
	                                @Amount decimal(18, 2),
	                                @PayType int,
	                                @OperationNumber varchar(50) = ''
                                AS
                                BEGIN
                                DECLARE @numberQuote int;

                                        BEGIN
                                             SET @numberQuote =(SELECT Max([Quote]) FROM [BeClever].[dbo].[CreditPayment] where [CreditId] = @CreditId)

		                                     IF (@numberQuote IS NULL)
				                                BEGIN
                                                SET @numberQuote = 1
		                                        END
                                             ELSE
			                                    BEGIN
                                                SET @numberQuote = @numberQuote + 1
			                                 END
		                                  END

	                                INSERT INTO [dbo].[CreditPayment]([CreditId],[Quote],[Amount],[PayType],[OperationNumber],[PayDate],[Active],[PendingAmount])
                                     VALUES
                                           (@CreditId
                                           ,@numberQuote
                                           ,@Amount
                                           ,@PayType
                                           ,@OperationNumber
                                           ,GETDATE()
                                           ,1
                                           ,0)

                                BEGIN
									  EXECUTE dbo.SP_AFECTAR_CUOTA @numberQuote, @CreditId
                                END
                                END
                                

            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE[dbo].[SP_AFECTAR_CUOTA]");
            migrationBuilder.Sql(@"DROP PROCEDURE[dbo].[SP_ALTA_PAGO]");
        }
    }
}
