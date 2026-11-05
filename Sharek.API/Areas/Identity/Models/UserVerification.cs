using System.ComponentModel.DataAnnotations;

namespace Sharek.API.Areas.Identity.Models
{
    public class UserVerification
    {
        [Key]
        public int VerificationId { get; set; }
        public int UserId { get; set; } // Foreign Key
        public string NationalId { get; set; }
        public string IdImage { get; set; }
        public bool Verified { get; set; } = false;

        public User User { get; set; } // Navigation Property
    }
}