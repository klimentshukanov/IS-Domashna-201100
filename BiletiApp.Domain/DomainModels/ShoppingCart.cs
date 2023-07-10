using BiletiApp.Domain.Identity;
using BiletiApp.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiletiApp.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        //public Guid ShoppingCartId { get; set; }

        public string UserId { get; set; }
        public virtual CustomUser User { get; set; }

        public virtual ICollection<BiletShoppingCart> BiletiShoppingCarts { get; set; }
    }
}
