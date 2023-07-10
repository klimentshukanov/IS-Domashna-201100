using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BiletiApp.Domain.DTO
{
    public class UserRegistrationDto
    {
        [Required(ErrorMessage = "Mora da vnesete ime")]
        [StringLength(100)]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Mora da vnesete prezime")]
        [StringLength(100)]
        public string Prezime { get; set; }

        [EmailAddress(ErrorMessage = "Nevalidna email adresa")]
        [Required(ErrorMessage = "Mora da vnesete email adresa")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mora da vnesete lozinka")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mora povtorno da ja vnesete lozinkata")]
        [Compare("Password", ErrorMessage = "Lozinkite ne se sovpagjaat.")]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }
    }
}
