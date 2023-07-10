using BiletiApp.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiletiApp.Domain.Identity
{
    public class CustomUser : IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }


        public virtual ShoppingCart UserCart { get; set; }
    }
}
