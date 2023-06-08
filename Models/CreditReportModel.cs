using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeCleverChallenge.Services.Credit.Dto
{
    public class CreditReportModel
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
        public DateTime? CreatedAt { get; set; }
        public DateTime? FinalizedDate { get; set; }
        public decimal? AmountPay { get; set; }
    }
}
