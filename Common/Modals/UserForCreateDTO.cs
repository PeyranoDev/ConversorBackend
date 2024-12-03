using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modals
{
    public class UserForCreateDTO
    {
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(100)]
        [MinLength(8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(100)]
        [MinLength(8)]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
        public string SecondPassword { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [Range(1, 3)]
        public int SubscriptionId { get; set; }
    }
}
