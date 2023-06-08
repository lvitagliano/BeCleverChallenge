using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeCleverChallenge.Models
{
    public class ClientModel
    {
        [Required]
        [Key, Column("Id", TypeName = "int")]
        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Address { get; set; }
        public bool Active { get; set; }
    }
}
