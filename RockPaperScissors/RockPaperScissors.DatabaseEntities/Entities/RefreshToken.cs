using System.ComponentModel.DataAnnotations;

namespace RockPaperScissors.DatabaseEntities.Entities
{
    public class RefreshToken : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClientId { get; set; }

        [Required]
        public string ProtectedTicket { get; set; }
    }
}
