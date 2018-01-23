using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore.Models.Requests
{
    public class RegisterUserRequest
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public String Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password must be minimul 6 characters length!", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",ErrorMessage = " The confirmation password must match to password!")]
        public String ConfirmPassword { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = " Name must have at least 3 characters!")]
        public String Name { get; set; }

    }
}
