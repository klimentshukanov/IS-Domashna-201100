using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace BiletiApp.Domain.DTO
{
    public class LogiranjeDTO
    {
        [Required(ErrorMessage = "Mora da vnesete email adresa")]
        [EmailAddress(ErrorMessage = "Email adresata ne e validna")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mora da vnesete lozinka")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
