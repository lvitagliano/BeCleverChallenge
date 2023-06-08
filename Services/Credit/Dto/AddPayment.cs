namespace BeCleverChallenge.Services.Credit.Dto
{
    public class AddPayment
    {
        public int? CreditId { get; set; }
        public decimal? Amount { get; set; }
        public int? PayType { get; set; }
        public string? OperationNumber { get; set; }
    }
}