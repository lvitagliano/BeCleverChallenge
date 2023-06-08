using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeCleverChallenge.Services.Credit.Dto
{
    public class InserCredit
    {
        public decimal? Amount { get; set; }
        public decimal? InterestPercent { get; set; }
        public int? QuantityQuote { get; set; }
        public decimal? Iva { get; set; }
        public int? ExpirationDay { get; set; }
        public decimal? DelayInterestPercent { get; set; }
        public int? UserId { get; set; }
        public int? ClientId { get; set; }
        public bool? Active { get; set; }
    }
}
