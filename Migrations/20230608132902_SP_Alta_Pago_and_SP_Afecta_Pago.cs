using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeCleverChallenge.Migrations
{
    /// <inheritdoc />
    public partial class SP_Alta_Pago_and_SP_Afecta_Pago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"GO
                                    CREATE PROCEDURE SP_AFECTAR_CUOTA 
                                    @Quote int,
                                    @CreditId int,
                                    @finalizedCredit int
                                    AS
                                    BEGIN
                                        IF (@finalizedCredit = 0)
                                            BEGIN
                                                UPDATE [dbo].[Credit] SET [PaidQuotes] = @Quote WHERE Id = @CreditId
                                            END 
                                        ELSE
                                            BEGIN
                                                UPDATE [dbo].[Credit] SET [PaidQuotes] = @Quote, [FinalizedDate] = GETDATE() WHERE Id = @CreditId
                                            END
	
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
								                    DECLARE @quoteOfCredit int;
								                    DECLARE @finalizedDate datetime = null;
								                    DECLARE @finalizedCredit int;
                                                        BEGIN
                                                                 SET @numberQuote =(SELECT Max([Quote]) FROM [dbo].[CreditPayment] where [CreditId] = @CreditId)
											                     SET @quoteOfCredit =(SELECT [QuantityQuote] FROM [BeClever].[dbo].[Credit] where Id = @CreditId)
											                     SET @finalizedDate =(SELECT [FinalizedDate] FROM [BeClever].[dbo].[Credit] where Id = @CreditId)
									
		                                                         IF (@numberQuote IS NULL)
				                                                    BEGIN
													                    SET @numberQuote = 1
		                                                            END
                                                                 ELSE
			                                                        BEGIN
													                    SET @numberQuote = @numberQuote + 1
												                    END

										                      IF (@numberQuote >= @quoteOfCredit)
											                       BEGIN
													                    SET @finalizedCredit = 1
											                       END 
										                      ELSE
											                       BEGIN
													                    SET @finalizedCredit = 0
											                       END
									                    END
                    --Si existe fecha de finalizacion no impacta pago 
				                    IF(@finalizedDate IS NULL)
				                      BEGIN
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
									                      EXECUTE dbo.SP_AFECTAR_CUOTA @numberQuote, @CreditId, @finalizedCredit
                                                    END
				                    END
				                    ELSE
				                     BEGIN
						                    SELECT @finalizedCredit
                                     END
		
	                END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE[dbo].[SP_AFECTAR_CUOTA]");
            migrationBuilder.Sql(@"DROP PROCEDURE[dbo].[SP_ALTA_PAGO]");
        }
    }
}
