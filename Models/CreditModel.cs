using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeCleverChallenge.Models
{
    public class CreditModel
    {
        [Required]
        [Key, Column("Id", TypeName = "int")]
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public decimal? InterestPercent { get; set; }
        public decimal? Interest { get; set; }
        public decimal? AmountWithInterest { get; set; }
        public decimal? PureQuoteValue { get; set; }
        public decimal? Quote { get; set; }
        public int? QuantityQuote { get; set; }
        public int? PaidQuotes { get; set; }
        public decimal? Iva { get; set; }
        public int? ExpirationDay { get; set; }
        public decimal? DelayInterestPercent { get; set; }
        public int? UserId { get; set; }
        public int? ClientId { get; set; }
        public bool? Active { get; set; }
    }
}
