using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore.Models.Requests
{
    public class RegisterOrUpdateUserRequest
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public String Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password must have from 6 to 50 characters!", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",ErrorMessage = " The confirmation password must match to password!")]
        public String ConfirmPassword { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = " Name must have from 6 to 30 characters!", MinimumLength = 6)]
        public String Name { get; set; }
        
        [StringLength(500, ErrorMessage = " Description cannot be longer then 500 characters")]
        public String Desription { get; set; }

    }
}
