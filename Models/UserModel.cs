using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeCleverChallenge.Models
{
    public class UserModel
    {
        [Required]
        [Key, Column("Id", TypeName = "int")]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
