using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestPlatform.Server.Models
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(500)]
        public string Token { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}

