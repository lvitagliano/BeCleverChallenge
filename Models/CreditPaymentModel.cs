using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeCleverChallenge.Models
{
    public class CreditPaymentModel
    {
        [Required]
        [Key, Column("Id", TypeName = "int")]
        public int Id { get; set; }
        public int CreditId { get; set; }
        public int Quote { get; set; }
        public decimal Amount { get; set; }
        public decimal PendingAmount{ get; set; }
        public int PayType { get; set; }
        public string? OperationNumber { get; set; }
        public DateTime? PayDate { get; set; }
        public bool? Active { get; set; }
    }
}
